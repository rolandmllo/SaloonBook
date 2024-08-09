using App.Domain;
using App.Domain.Identity;
using BLL.App.Mappers;
using BLL.Base;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Identity;
using Public.DTO.v1;
using Appointment = App.Domain.Appointment;
using AppointmentScheduleByEmployeeName = BLL.DTO.AppointmentScheduleByEmployeeName;
using AppointmentServices = App.Domain.AppointmentServices;
using Service = App.Domain.Service;

namespace BLL.App.Services;

public class AppointmentsScheduleService : 
    BaseEntityService<BLL.DTO.Appointment, Appointment, IAppointmentsRepository> , 
    IAppointmentsService
{
    protected IAppUOW Uow;
    private IAppBLL _bll;
    private UserManager<AppUser> _userManager;
    private IAppointmentsService? _appointmentsServiceImplementation;

    public AppointmentsScheduleService(IAppUOW uow, IMapper<BLL.DTO.Appointment, 
        Appointment> mapper, UserManager<AppUser> userManager, IAppBLL bll)
        : base(uow.AppointmentsRepository, mapper)
    {
        Uow = uow;
        _userManager = userManager;
        _bll = bll;
    }

    public async Task<DTO.Appointment> CreateAppointment(DTO.Appointment appointment)
    {
        var newAppointment = Mapper.Map(appointment);
        
        if (newAppointment != null)
        {
            newAppointment.Id = Guid.NewGuid();
            newAppointment.CreatedAt = DateTime.Now.ToUniversalTime();
            newAppointment.Client = _userManager.FindByIdAsync(appointment.ClientId.ToString()).Result!;
            newAppointment.ClientId = appointment.ClientId;
            newAppointment.ReservationFrom = appointment.StartTime.ToUniversalTime();
            newAppointment.ReservationUntil = appointment.EndTime.ToUniversalTime();
            newAppointment.Employee = _bll.UsersService.GetEmployeeByIdAsync(newAppointment.EmployeeId).Result;
            newAppointment.SalonId = appointment.SalonId;
            newAppointment.Salon = Uow.SalonRepository.FindAsync(appointment.SalonId).Result!;
            newAppointment.AppointmentServices = new List<AppointmentServices>();
            newAppointment.CategoryId = appointment.CategoryId;
            newAppointment.ServiceId = appointment.ServiceId;
            var appointmentService = GetNewAppointmentService(appointment);
            newAppointment.AppointmentServices.Add(appointmentService);
            appointmentService.Appointment = newAppointment;
            appointmentService.AppointmentId = newAppointment.Id;

            Uow.AppointmentsRepository.Add(newAppointment);
        }
        else
        {
            throw new InvalidDataException();
        }
        await Uow.SaveChangesAsync();
        
        var createdAppointment = Mapper.Map(newAppointment)!;
        createdAppointment.CategoryId = appointment.CategoryId;

        return createdAppointment;
    }

    private AppointmentServices GetNewAppointmentService(DTO.Appointment appointment)
    {
        var service = Uow.ServiceRepository.FindServicesByCategoryIdAsync(appointment.CategoryId)
            .Result.FirstOrDefault();
        var appointmentService = new AppointmentServices()
        {
            Id = Guid.NewGuid(),
            Service = service!,
            ServiceId = service!.Id,
        };

        return appointmentService;
    }
    
    public async Task<DTO.Appointment> UpdateAppointment(DTO.Appointment? appointment)
    {
        if (appointment == null)
        {
            throw new ArgumentNullException(nameof(appointment));
        }
        var existingAppointment = Uow.AppointmentsRepository
            .FindAsync(appointment.Id).Result;
        
        //await Uow.SaveChangesAsync();
        
        if (existingAppointment == null)
        {
            throw new KeyNotFoundException($"Appointment with ID {appointment.Id} not found.");
        }
        
        var appointmentService = GetNewAppointmentService(appointment);
        existingAppointment.AppointmentServices.Add(appointmentService);
        appointmentService.Appointment = existingAppointment;
        appointmentService.AppointmentId = existingAppointment.Id;



        existingAppointment.ClientId = appointment.ClientId;
        existingAppointment.EmployeeId = appointment.EmployeeId;
        existingAppointment.ReservationFrom = appointment.StartTime.ToUniversalTime();
        existingAppointment.ReservationUntil = appointment.EndTime.ToUniversalTime();
        existingAppointment.CreatedAt = DateTime.Now.ToUniversalTime();
        existingAppointment.SalonId = appointment.SalonId;
        // existingAppointment.Comment = appointment.Comment;
        Uow.AppointmentsRepository.Update(existingAppointment);

        await Uow.SaveChangesAsync();

        return Mapper.Map(existingAppointment)!;
    }
    

    public async Task<IEnumerable<AppointmentScheduleByEmployeeName>> GetPublicSchedulesByEmployee(string categoryName, string salonName)
    {
        List<AppointmentScheduleByEmployeeName> appointmentScheduleByEmployeeNames = new List<AppointmentScheduleByEmployeeName>();

        // Retrieve the necessary data from repositories
        var categories = await Uow.CategoryRepository.AllAsync();
        var salon = await Uow.SalonRepository.FindAsync(new Guid(salonName));
        //var employees = Uow.EmployeeServiceRepository.GetEmployeesByCategoryAndSalon(categoryName, salonName);
        var employees = Uow.EmployeeServiceRepository.AllAsync().Result;
        var schedules = await Uow.ScheduleRepository.GetPublicSchedulesByEmployees(employees);
        var appointments =  await Uow.AppointmentsRepository.GetAppointmentsByEmployees(employees);

        foreach (var schedule in schedules)
        {
            var employee = employees.FirstOrDefault(e => e.Id == schedule.EmployeeId);
            var category = categories.FirstOrDefault(c => c.Id == employee!.Service.CategoryId);
            //var salon = salons.FirstOrDefault(s => s.Id == employee!.Service.);

            if (employee != null && category != null && salon != null)
            {
                var scheduleDto = new AppointmentScheduleByEmployeeName()
                {
                    EmployeeFirstName = employee.Employee!.FirstName,
                    // Category = category.Name,
                    SalonName = salon.SalonName
                };

                var employeeAppointments = appointments.Where(a => a.EmployeeId == employee.Id);
                foreach (var appointment in employeeAppointments)
                {
                    var appointmentDto = new Appointment()
                    {
                        ReservationFrom = appointment.ReservationFrom.ToUniversalTime(),
                        ReservationUntil = appointment.ReservationUntil.ToUniversalTime()
                    };

                    scheduleDto.Appointments.Add(Mapper.Map(appointmentDto)!);
                }

                appointmentScheduleByEmployeeNames.Add(scheduleDto);
            }
        }

        return appointmentScheduleByEmployeeNames;
    }
    

    public async Task<AppointmentScheduleByEmployeeName> AppointmentsByServiceAndSalon(
        Guid salonId, Guid categorieId)
    {
        Console.WriteLine("user!.FirstName");
        var salon = await Uow.SalonRepository.FindAsync(salonId);
        var category = await Uow.CategoryRepository
            .FindAsync(categorieId);


        var appointments = await Uow.AppointmentsRepository
            .AppointmentsBySalonAndCategory(salonId, categorieId);
        

        return new AppointmentScheduleByEmployeeName()
        {
            EmployeeFirstName = appointments.First().Employee!.FirstName,
            EmployeeLastName = appointments.First().Employee!.LastName,            
            
            Appointments = new List<DTO.Appointment>()
            {
                new DTO.Appointment()
                {
                }
            }
        };
    }

    public async Task<bool> RemoveAsync(Guid id, Guid appUserId)
    {
        var appointment = Uow.AppointmentsRepository.FindAsync(id).Result;
        if (appointment == null)
        {
            return false;
        }
        if (appUserId != appointment.ClientId) return false;
        
        await Uow.AppointmentsRepository.RemoveAsync(id);
        await Uow.SaveChangesAsync();
        
        return true;
    }

    public DTO.Appointment? FindAsyncById(Guid id, Guid appUserId)
    {
        var appointment = Uow.AppointmentsRepository.FindAsync(id).Result;
        if (appointment == null || appUserId != appointment.ClientId)
        {
            return null!;
        }

        var a = Mapper.Map(appointment);

        return a;
    }


    


}