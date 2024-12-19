namespace Catalog.Application.Features.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category) : IQuery<Result<GetProductByCategoryResult>>;
