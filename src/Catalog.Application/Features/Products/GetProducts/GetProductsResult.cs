using Catalog.Domain.Core;
using Catalog.Domain.Features.Products;

namespace Catalog.Application.Features.Products.GetProducts;
public record GetProductsResult(PaginatedResult<Product> Products);
