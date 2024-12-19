namespace Catalog.Application.Features.Products.GetProducts;
public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<Result<GetProductsResult>>;
