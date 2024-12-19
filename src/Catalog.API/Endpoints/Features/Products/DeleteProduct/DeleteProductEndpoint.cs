using Catalog.API.Endpoints.Core;
using Catalog.Application.Features.Products.DeleteProduct;

namespace Catalog.API.Endpoints.Features.Products.DeleteProduct;



public class DeleteProductEndpoint : EndpointsBase
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id}/product", DeleteProduct)
        .WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }

    private static async Task<IResult> DeleteProduct(string id, ISender sender)
    {
        var response = await sender.Send(new DeleteProductCommand(id));

        return response.Match<IResult>
        (
            result => Results.NoContent(),
            error => ProcessError(error)
        );
    }
}
