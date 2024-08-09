using App.Domain.Identity;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using DAL.Contracts.App;
using DAL.EF.Base;
using Microsoft.AspNetCore.Identity;

namespace DAL.EF.App;

public class AppUOW : EFBaseUOW<ApplicationDbContext>, IAppUOW
{
    private UserManager<AppUser> _userManager;
    public AppUOW(ApplicationDbContext dataContext, UserManager<AppUser> userManager) : base(dataContext)
    {
        _userManager = userManager;
    }
    private IAppointmentsRepository? _appointmentsRepository;
    private IAppointmentServicesRepository? _appointmentServicesRepository;
    private ICategoryRepository? _categoryRepository;
    private ICityRepository? _cityRepository;
    private IEmployeeServiceRepository? _employeeServiceRepository;
    private ISalonRepository? _salonRepository;
    private IScheduleRepository? _scheduleRepository;
    private IServiceRepository? _serviceRepository;
    private IUserRepository? _userRepository;

    public IAppointmentsRepository AppointmentsRepository =>
        _appointmentsRepository ??= new AppointmentRepository(UowDbContext);
    
    public IAppointmentServicesRepository AppointmentServicesRepository =>
        _appointmentServicesRepository ??= new AppointmentServicesRepository(UowDbContext);
    
    public ICategoryRepository CategoryRepository =>
        _categoryRepository ??= new CategoryRepository(UowDbContext);
    
    public ICityRepository CityRepository =>
        _cityRepository ??= new CityRepository(UowDbContext);
    
    public IEmployeeServiceRepository EmployeeServiceRepository =>
        _employeeServiceRepository ??= new EmployeeServicesRepository(UowDbContext);
    
    public ISalonRepository SalonRepository =>
        _salonRepository ??= new SalonRepository(UowDbContext);
    
    public IScheduleRepository ScheduleRepository =>
        _scheduleRepository ??= new ScheduleRepository(UowDbContext);
    
    public IServiceRepository ServiceRepository =>
        _serviceRepository ??= new ServiceRepository(UowDbContext);

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(UowDbContext, _userManager);

}
