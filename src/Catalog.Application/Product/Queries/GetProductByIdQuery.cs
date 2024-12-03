using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Queries;
public record GetProductByIdQuery(string Id) : IQuery<Result<GetProductByIdResult>>;
