using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Commands;
public record DeleteProductCommand(string Id) : ICommand<DeleteProductResult>;
