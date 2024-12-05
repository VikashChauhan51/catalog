namespace Catalog.Application.Product.Responses;
public record GetProductByCategoryResult(IEnumerable<Catalog.Core.Entities.Product> Products);
