using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IWriteRepository<in T, in TKey> where T : IEntity where TKey : notnull
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(TKey id, CancellationToken cancellationToken);
}

