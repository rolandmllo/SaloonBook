using App.Domain;
using DAL.Contracts.Base;

namespace DAL.Contracts.App;

public interface IEmployeeServiceRepository
    : IBaseRepository<EmployeeServices>, IEmployeeServiceRepositoryCustom<EmployeeServices>

{
    
}


public interface IEmployeeServiceRepositoryCustom<TEntity>
{
    // add here shared methods between repo and service
    // Task<IEnumerable<TEntity>> AllAsync(Guid employeeId);
    // Task<TEntity?> FindAsync(Guid employeeId);
    // Task<TEntity?> RemoveAsync(Guid employeeId);
}