namespace Catalog.API.Endpoints.Features.Products.GetProducts;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
