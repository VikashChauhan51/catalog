using Catalog.Core.Entities;

namespace Catalog.Application.Core.Repositories;

public interface IProductRepository : IRepository<Product, string>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(string category, CancellationToken cancellationToken);
}

