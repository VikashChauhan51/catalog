using Catalog.Application.Product.Commands;
using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Handlers;
public class DeleteProductCommandHandler(IProductRepository productRepository)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        await productRepository.DeleteAsync(command.Id, cancellationToken);

        return new DeleteProductResult(true);
    }
}
