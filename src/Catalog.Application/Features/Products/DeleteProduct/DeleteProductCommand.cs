namespace Catalog.Application.Features.Products.DeleteProduct;
public record DeleteProductCommand(string Id) : ICommand<Result<Unit>>;
