namespace Catalog.API.Endpoints.Features.Products.CreateProduct;

public record CreateProductRequest
(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
);
