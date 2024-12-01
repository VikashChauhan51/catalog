namespace Catalog.Application.Commands;
public record UpdateProductCommand(string Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<UpdateProductResult>;
