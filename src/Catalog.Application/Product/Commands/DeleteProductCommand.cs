namespace Catalog.Application.Product.Commands;
public record DeleteProductCommand(string Id) : ICommand<Result<Unit>>;
