using Catalog.Application.Features.Products.Shared.Repositories;

namespace Catalog.Application.Features.Products.GetProductById;

public class GetProductByIdActor : ReceiveActor
{
    private readonly IProductRepository repository;

    public GetProductByIdActor(IProductRepository repository)
    {
        this.repository = repository;
        ReceiveAsync<GetProductByIdQuery>(async query =>
        {
            var product = await this.repository.GetByIdAsync(query.Id, CancellationToken.None);
            // Send result back to sander
            Sender.Tell(Result<GetProductByIdResult>.Succ(new GetProductByIdResult(product)));
        });
    }
}
