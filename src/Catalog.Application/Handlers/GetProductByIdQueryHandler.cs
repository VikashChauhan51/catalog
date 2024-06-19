namespace Catalog.Application.Handlers;
public class GetProductByIdQueryHandler(ILogger<GetProductByIdQueryHandler> logger, IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        logger.LogDebug("Product details {Product}", product);
        return new GetProductByIdResult(product);
    }
}
