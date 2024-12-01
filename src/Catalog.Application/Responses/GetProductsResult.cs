using Catalog.Core.Pagination;

namespace Catalog.Application.Responses;
public record GetProductsResult(PaginatedResult<Product> Products);
