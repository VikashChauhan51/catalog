using Catalog.Application.Product.Queries;
using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Handlers;
public class GetProductByCategoryQueryHandler(IProductRepository productRepository)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetByCategoryAsync(query.Category, cancellationToken);

        return new GetProductByCategoryResult(products);
    }
}
