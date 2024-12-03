using Catalog.Application.Product.Commands;

namespace Catalog.API.Endpoints.Product;

public record DeleteProductResponse(bool IsSuccess);

public class DeleteProductEndpoint : EndpointsBase, ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
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
