using Catalog.Application.Queries;

namespace Catalog.API.Endpoints.Product;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
public record GetProductsResponse(IEnumerable<ProductDto> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", GetProducts)
        .WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
    private static async Task<IResult> GetProducts([AsParameters] GetProductsRequest request, ISender sender)
    {
        var query = request.Adapt<GetProductsQuery>();

        var result = await sender.Send(query);

        var response = result.Adapt<GetProductsResponse>();

        return Results.Ok(response);
    }
}
