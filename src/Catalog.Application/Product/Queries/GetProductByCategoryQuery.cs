using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Queries;

public record GetProductByCategoryQuery(string Category) : IQuery<Result<GetProductByCategoryResult>>;
