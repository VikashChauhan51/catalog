using Catalog.Application.Product.Queries;
using Catalog.Application.Product.Responses;

namespace Catalog.Application.Product.Actors;

public class GetProductByCategoryActor : ReceiveActor
{
    private readonly IProductRepository repository;

    public GetProductByCategoryActor(IProductRepository repository)
    {
        this.repository = repository;
        ReceiveAsync<GetProductByCategoryQuery>(async query =>
        {
            var products = await this.repository.GetByCategoryAsync(query.Category, CancellationToken.None);
            // Send result back to sander
            Sender.Tell(Result<GetProductByCategoryResult>.Succ(new GetProductByCategoryResult(products)));
        });
    }
}
