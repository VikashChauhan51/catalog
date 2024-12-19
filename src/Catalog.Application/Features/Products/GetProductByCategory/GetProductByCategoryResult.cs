using Catalog.Domain.Features.Products;

namespace Catalog.Application.Features.Products.GetProductByCategory;
public record GetProductByCategoryResult(IEnumerable<Product> Products);
