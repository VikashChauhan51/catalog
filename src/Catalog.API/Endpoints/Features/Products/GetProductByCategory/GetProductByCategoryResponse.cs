using Catalog.API.Endpoints.Features.Products.Shared;

namespace Catalog.API.Endpoints.Features.Products.GetProductByCategory;

public record GetProductByCategoryResponse(IEnumerable<ProductDto> Products);
