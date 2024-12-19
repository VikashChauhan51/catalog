using Catalog.Application.Features.Products.Shared.Repositories;

namespace Catalog.Application.Features.Products.DeleteProduct;
internal class DeleteProductActor : ReceiveActor
{
    private readonly IProductRepository repository;

    public DeleteProductActor(IProductRepository repository)
    {
        this.repository = repository;

        ReceiveAsync<DeleteProductCommand>(async command =>
        {
            await this.repository.DeleteAsync(command.Id, CancellationToken.None);
        });
    }
}
