namespace Catalog.Application.Handlers;
public class DeleteProductCommandHandler(IProductRepository productRepository)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        await productRepository.DeleteAsync(command.Id, cancellationToken);

        return new DeleteProductResult(true);
    }
}
