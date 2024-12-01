using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProductRepository : IRepository<Product, string>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(string category, CancellationToken cancellationToken);
}

