using Catalog.Application.Product.Queries;
using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Actors;

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
