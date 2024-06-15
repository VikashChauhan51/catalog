namespace Catalog.API.Products.GetProductById;

 

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);

internal class GetProductByIdQueryHandler(ILogger<GetProductByIdQueryHandler> logger, IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        logger.LogDebug("Product details {Product}", product);
        return new GetProductByIdResult(product);
    }
}
