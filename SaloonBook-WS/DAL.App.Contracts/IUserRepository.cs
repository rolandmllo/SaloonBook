using App.Domain.Identity;
using DAL.Contracts.Base;

namespace DAL.Contracts.App;

public interface IUserRepository : IBaseRepository<AppUser>, IUserRepositoryCustom<AppUser>
{
}

public interface IUserRepositoryCustom<TEntity>
{
    
    Task<IEnumerable<AppUser>> GetAllEmployees();
    
}