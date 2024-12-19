using Catalog.Application.Features.Products.Shared.Repositories;
using Catalog.Domain.Features.Products;
using Catalog.Infrastructure.Repositories;
using Marten;

namespace Catalog.Infrastructure.Features.Products;

public class ProductRepository : Repository<Product, string>, IProductRepository
{
    private readonly IDocumentSession _documentSession;

    public ProductRepository(IDocumentSession documentSession) : base(documentSession)
    {
        _documentSession = documentSession;
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(string category, CancellationToken cancellationToken)
    {
        return await _documentSession
            .Query<Product>()
            .Where(product => product.Category.Contains(category))
            .ToListAsync(cancellationToken);
    }
}

