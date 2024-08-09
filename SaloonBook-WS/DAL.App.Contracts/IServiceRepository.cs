using App.Domain;
using DAL.Contracts.Base;

namespace DAL.Contracts.App;

public interface IServiceRepository
    : IBaseRepository<Service>, IServiceRepositoryCustom<Service>
{
    Task<IEnumerable<Service>> FindServicesByCategoryIdAsync(Guid categoryId);
    
}

public interface IServiceRepositoryCustom<TEntity>
{
    // add here shared methods between repo and service

    // Task<IEnumerable<TEntity>> AllAsync();

    // Task<TEntity?> FindAsync(Guid serviceId);
}