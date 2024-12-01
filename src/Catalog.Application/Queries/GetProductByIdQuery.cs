namespace Catalog.Application.Queries;
public record GetProductByIdQuery(string Id) : IQuery<GetProductByIdResult>;
