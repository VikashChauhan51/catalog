using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Queries;
public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<Result<GetProductsResult>>;
