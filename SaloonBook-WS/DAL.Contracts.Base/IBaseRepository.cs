﻿using Domain.Contracts.Base;

namespace DAL.Contracts.Base;

public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, Guid>
    where TEntity : class, IDomainEntityId
{
}

public interface IBaseRepository<TEntity, in TKey>
    where TEntity : class, IDomainEntityId<TKey> 
    where TKey : struct, IEquatable<TKey>
{
    // IEnumerable<TEntity> All();
    // TEntity Find(TKey id);
    Task<IEnumerable<TEntity>> AllAsync();
    Task<TEntity?> FindAsync(TKey id);
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Remove(TEntity entity);
    Task<TEntity?> RemoveAsync(TKey id);
}