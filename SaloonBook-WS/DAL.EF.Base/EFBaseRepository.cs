using DAL.Contracts.Base;
using Domain.Contracts.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.Base;

public class EFBaseRepository<TEntity, TDbContext> : EFBaseRepository<TEntity, Guid, TDbContext>,
    IBaseRepository<TEntity>
    where TEntity : class, IDomainEntityId
    where TDbContext : DbContext
{
    public EFBaseRepository(TDbContext dataContext) : base(dataContext)
    {
    }
}

public class EFBaseRepository<TEntity, TKey, TDbContext> : IBaseRepository<TEntity, TKey>
    where TEntity : class, IDomainEntityId<TKey>
    where TKey : struct, IEquatable<TKey>
    where TDbContext : DbContext
{
    protected readonly TDbContext _repositoryDbContext;
    protected  DbSet<TEntity> RepositoryDbSet;

    protected EFBaseRepository(TDbContext dataContext)
    {
        _repositoryDbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        RepositoryDbSet = _repositoryDbContext.Set<TEntity>();
    }


    public virtual async Task<IEnumerable<TEntity>> AllAsync()
    {
        return await RepositoryDbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> FindAsync(TKey id)
    {
        return await RepositoryDbSet.FindAsync(id);
    }

    public virtual TEntity Add(TEntity entity)
    {
        return RepositoryDbSet.Add(entity).Entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        return RepositoryDbSet.Update(entity).Entity;
    }

    public virtual TEntity Remove(TEntity entity)
    {
        return RepositoryDbSet.Remove(entity).Entity;
    }

    public virtual async Task<TEntity?> RemoveAsync(TKey id)
    {
        var entity = await FindAsync(id);
        await _repositoryDbContext.SaveChangesAsync();
        return entity != null ? Remove(entity) : null;
    }
}