﻿namespace Catalog.API.Products.GetProductByCategory;

 
public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);

internal class GetProductByCategoryQueryHandler
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        //var products = await session.Query<Product>()
        //    .Where(p => p.Category.Contains(query.Category))
        //    .ToListAsync(cancellationToken);

        return new GetProductByCategoryResult(null);
    }
}
