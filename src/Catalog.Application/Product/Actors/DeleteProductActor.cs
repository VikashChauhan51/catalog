using Catalog.Application.Product.Commands;


namespace Catalog.Application.Product.Actors;
internal class DeleteProductActor: ReceiveActor
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
