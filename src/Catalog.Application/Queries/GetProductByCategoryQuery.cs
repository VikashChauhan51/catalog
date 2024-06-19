namespace Catalog.Application.Queries;

public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
