using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Commands;
public record CreateProductCommand(string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price)
    : ICommand<CreateProductResult>;
