using Catalog.API.Endpoints.Core;
using Catalog.Application.Features.Products.GetProducts;

namespace Catalog.API.Endpoints.Features.Products.GetProducts;




public class GetProductsEndpoint : EndpointsBase
{
    public override void AddRoutes(IEndpointRouteBuilder app)
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
        var response = await sender.Send(query);

        return response.Match<IResult>
        (
               result => Results.Ok(result),
              error => ProcessError(error)
        );
    }
}
