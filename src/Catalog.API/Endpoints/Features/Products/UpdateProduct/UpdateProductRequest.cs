namespace Catalog.API.Endpoints.Features.Products.UpdateProduct;

public record UpdateProductRequest
(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
);
