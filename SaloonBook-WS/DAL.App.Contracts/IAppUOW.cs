using DAL.Contracts.Base;

namespace DAL.Contracts.App;

public interface IAppUOW : IBaseUOW
{
   // list your repositories here
   IAppointmentsRepository AppointmentsRepository { get; }
   IAppointmentServicesRepository AppointmentServicesRepository { get; }
   ICategoryRepository CategoryRepository { get; }
   ICityRepository CityRepository { get; }
   IEmployeeServiceRepository EmployeeServiceRepository { get; }
   ISalonRepository SalonRepository { get; }
   IScheduleRepository ScheduleRepository { get; }
   IServiceRepository ServiceRepository { get; }
   IUserRepository UserRepository { get; }
   
}