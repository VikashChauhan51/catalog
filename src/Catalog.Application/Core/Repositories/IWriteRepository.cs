using Catalog.Domain.Core;

namespace Catalog.Application.Core.Repositories;

public interface IWriteRepository<in T, in TKey> where T : IEntity where TKey : notnull
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(TKey id, CancellationToken cancellationToken);
}

