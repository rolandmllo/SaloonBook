using DAL.Contracts.Base;
using Category = App.Domain.Category;

namespace DAL.Contracts.App;

public interface ICategoryRepository
    : IBaseRepository<Category>, ICategoryRepositoryCustom<Category>
{
    // add here custom methods for repo only
}

public interface ICategoryRepositoryCustom<TEntity>
{
    // add here shared methods between repo and service
    //Task<IEnumerable<TEntity>> AllAsync();
    //Task<TEntity?> FindAsync(Guid id);
    //Task<TEntity?> RemoveAsync(Guid id, Guid appointmentId);
}