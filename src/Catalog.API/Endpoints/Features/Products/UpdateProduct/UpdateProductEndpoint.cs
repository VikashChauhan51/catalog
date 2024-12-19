using Catalog.API.Endpoints.Core;
using Catalog.Application.Features.Products.UpdateProduct;

namespace Catalog.API.Endpoints.Features.Products.UpdateProduct;

public class UpdateProductEndpoint : EndpointsBase
{
    public override void AddRoutes(IEndpointRouteBuilder app)
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

