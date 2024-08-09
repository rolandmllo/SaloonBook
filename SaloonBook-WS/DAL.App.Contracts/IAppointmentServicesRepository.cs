using App.Domain;
using DAL.Contracts.Base;

namespace DAL.Contracts.App;



public interface IAppointmentServicesRepository 
    : IBaseRepository<AppointmentServices>, IAppointmentServicesRepositoryCustom<AppointmentServices>
{
    // add here custom methods for repo only
}


public interface IAppointmentServicesRepositoryCustom<TEntity>
{
    
    // add here shared methods between repo and service
    //Task<IEnumerable<TEntity>> AllAsync(Guid userId);
    //Task<TEntity?> FindAsync(Guid id, Guid appointmentId);
    //Task<TEntity?> RemoveAsync(Guid id, Guid appointmentId);
}