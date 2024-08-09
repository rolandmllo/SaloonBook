using App.Domain;
using DAL.Contracts.Base;

namespace DAL.Contracts.App;

public interface ICityRepository
    : IBaseRepository<City>, ICityRepositoryCustom<City>

{
    // add here custom methods for repo only
}

public interface ICityRepositoryCustom<TEntity>
{
    // add here shared methods between repo and service
    // Task<IEnumerable<TEntity>> AllAsync(Guid userId);
    // Task<TEntity?> FindAsync(Guid id);
}