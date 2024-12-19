using Catalog.API.Endpoints.Features.Products.Shared;

namespace Catalog.API.Endpoints.Features.Products.GetProducts;

public record GetProductsResponse(IEnumerable<ProductDto> Products);
