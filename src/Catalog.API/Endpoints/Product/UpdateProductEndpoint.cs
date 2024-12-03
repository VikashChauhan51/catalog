using Catalog.Application.Product.Commands;

namespace Catalog.API.Endpoints.Product;

public record UpdateProductRequest(Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);
public record UpdateProductResponse(bool IsSuccess);

public class UpdateProductEndpoint : EndpointsBase, ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/product", UpdateProduct)
            .WithName("UpdateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
    }

    private static async Task<IResult> UpdateProduct(UpdateProductRequest request, ISender sender)
    {
        var command = request.Adapt<UpdateProductCommand>();
        var response = await sender.Send(command);

        return response.Match<IResult>
        (
              result => Results.NoContent(),
              error => ProcessError(error)
        );
    }
}

