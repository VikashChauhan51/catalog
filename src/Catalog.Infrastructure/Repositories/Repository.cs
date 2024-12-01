using Catalog.Core.Entities;
using Catalog.Core.Pagination;
using Catalog.Core.Repositories;
using Marten;
using Marten.Pagination;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Repositories;

public class Repository<T, TKey> : IRepository<T, TKey> where T : IEntity where TKey : notnull
{
    private readonly IDocumentSession _documentSession;

    public Repository(IDocumentSession documentSession)
    {
        _documentSession = documentSession ?? throw new ArgumentNullException(nameof(documentSession));
    }

    // Read operations
    public async Task<T?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        return await _documentSession.LoadAsync<T>(id, cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _documentSession.Query<T>().ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _documentSession.Query<T>().Where(predicate).ToListAsync(cancellationToken);
    }

    // Write operations
    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(entity));
        _documentSession.Store(entity);
        await _documentSession.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(entity));
        _documentSession.Update(entity);
        await _documentSession.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity not found");
        }

        _documentSession.Delete(entity);
        await _documentSession.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginatedResult<T>> GetPagedListAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var pageResult = await _documentSession
           .Query<T>()
           .ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        return new PaginatedResult<T>(
            pageResult.Count,
            pageResult.PageNumber,
            pageResult.PageSize,
            pageResult.PageCount,
            pageResult.TotalItemCount,
            pageResult.HasPreviousPage,
            pageResult.HasNextPage,
            pageResult.IsFirstPage,
            pageResult.IsLastPage,
            pageResult
            );

    }
}


