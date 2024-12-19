namespace Catalog.Application.Features.Products.GetProductById;
public record GetProductByIdQuery(string Id) : IQuery<Result<GetProductByIdResult>>;
