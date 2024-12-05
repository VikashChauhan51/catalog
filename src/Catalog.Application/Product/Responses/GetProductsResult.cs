using Catalog.Core.Pagination;

namespace Catalog.Application.Product.Responses;
public record GetProductsResult(PaginatedResult<Catalog.Core.Entities.Product> Products);
