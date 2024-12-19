using Catalog.Domain.Features.Products;


namespace Catalog.Application.Features.Products.Shared.Repositories;
public interface IProductRepository : IRepository<Product, string>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(string category, CancellationToken cancellationToken);
}
