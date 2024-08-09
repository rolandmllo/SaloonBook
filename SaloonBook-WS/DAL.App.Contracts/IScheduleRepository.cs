using App.Domain;
using DAL.Contracts.Base;

namespace DAL.Contracts.App;

public interface IScheduleRepository : 
    IBaseRepository<Schedule>, IScheduleRepositoryCustom<Schedule>
{
    Task<IEnumerable<Schedule>> GetPublicSchedulesByEmployees(IEnumerable<EmployeeServices> employees);
    
    
}

public interface IScheduleRepositoryCustom<TEntity>
{

    // add here shared methods between repo and service

    // Task<IEnumerable<TEntity>> AllAsync(Guid employeeId);

    // Task<IEnumerable<TEntity>> AllAsyncBySalonAndDate(Guid salonId, DateTime date);

    // Task<TEntity?> FindAsync(Guid employeeId);
    // Task<TEntity?> RemoveAsync(Guid employeeId);
}