using Catalog.Application.Product.Queries;
using Catalog.Application.Product.Responses;
namespace Catalog.Application.Product.Actors;

public class GetProductsActor : ReceiveActor
{
    private readonly IProductRepository repository;
    public GetProductsActor(IProductRepository repository)
    {
        this.repository = repository;
        ReceiveAsync<GetProductsQuery>(async query =>
        {
            var products = await this.repository.GetPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, CancellationToken.None);
            // Send result back to sander
            Sender.Tell(Result<GetProductsResult>.Succ(new GetProductsResult(products)));
        });
    }
}
