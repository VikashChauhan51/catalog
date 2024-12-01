using Catalog.Core.Pagination;

namespace Catalog.Application.Product.Responses;
public record GetProductsResult(PaginatedResult<Core.Entities.Product> Products);
