using Catalog.Core.Entities;
using Catalog.Core.Pagination;

namespace Catalog.Core.Repositories;

public interface IReadRepository<T, in TKey> where T : IEntity where TKey : notnull
{
    Task<T?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

    Task<PaginatedResult<T>> GetPagedListAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
    Task<IEnumerable<T>> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}
