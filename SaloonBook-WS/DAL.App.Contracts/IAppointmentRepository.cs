using App.Domain;
using DAL.Contracts.Base;
namespace DAL.Contracts.App;

public interface IAppointmentsRepository : IBaseRepository<Appointment>, IAppointmentRepositoryCustom<Appointment>
{
    // add here custom methods for repo only
    // new Task<IEnumerable<Appointment>> AllAsync();
    Task<IEnumerable<Appointment>> AppointmentsBySalonAndCategory(Guid salonId, Guid serviceId);
    Task<IEnumerable<Appointment>> GetAppointmentsByEmployees(IEnumerable<EmployeeServices> employees);
}


public interface IAppointmentRepositoryCustom<TEntity>
{
    // add here shared methods between repo and service
    //Task<IEnumerable<Appointment>> AllAsync();

    //Task<TEntity?> FindAsync(Guid id, Guid userId);
    // Task<TEntity?> RemoveAsync(Guid id, Guid userId);
    // Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
    // Task<IEnumerable<TrainingPlanWithEventCount>> AllWithPlanCountAsync(Guid userId);
    
}