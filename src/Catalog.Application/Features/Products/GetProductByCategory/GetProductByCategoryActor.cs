using Catalog.Application.Features.Products.Shared.Repositories;

namespace Catalog.Application.Features.Products.GetProductByCategory;

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
