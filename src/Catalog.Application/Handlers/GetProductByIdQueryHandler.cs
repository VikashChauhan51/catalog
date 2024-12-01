﻿namespace Catalog.Application.Handlers;
public class GetProductByIdQueryHandler(ILogger<GetProductByIdQueryHandler> logger, IProductRepository productRepository)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(query.Id, cancellationToken);
        logger.LogDebug("Product details {Product}", product);
        return new GetProductByIdResult(product);
    }
}
