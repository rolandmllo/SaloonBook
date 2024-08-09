using App.Domain;
using DAL.Contracts.Base;

namespace DAL.Contracts.App;

public interface ISalonRepository
    : IBaseRepository<Salon>, ISalonRepositoryCustom<Salon>

{
    // Task<Salon?> FindAsync(string salonName);
}

public interface ISalonRepositoryCustom<TEntity>
{
    // add here shared methods between repo and service
    // Task<Task<Salon?>> GetSalonByName(string salonName);

    // Task<TEntity?> AllAsyncWithCities();
    // Task<TEntity?> FindAsync(Guid salonId);
    // Task<TEntity?> RemoveAsync(Guid salonId);
}