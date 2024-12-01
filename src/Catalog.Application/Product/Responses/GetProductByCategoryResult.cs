namespace Catalog.Application.Product.Responses;
public record GetProductByCategoryResult(IEnumerable<Core.Entities.Product> Products);
