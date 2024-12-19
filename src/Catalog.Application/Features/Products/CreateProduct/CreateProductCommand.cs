namespace Catalog.Application.Features.Products.CreateProduct;
public record CreateProductCommand(string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price)
    : ICommand<Result<Unit>>;
