using Catalog.API.Endpoints.Core;
using Catalog.Application.Features.Products.CreateProduct;

namespace Catalog.API.Endpoints.Features.Products.CreateProduct;


public class CreateProductEndpoint : EndpointsBase
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/product", CreateProduct)
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product")
        .WithOpenApi();
    }


    private static async Task<IResult> CreateProduct(CreateProductRequest request, ISender sender)
    {
        var command = request.Adapt<CreateProductCommand>();
        var response = await sender.Send(command);

        return response.Match<IResult>
        (
            result => Results.Created(),
            error => ProcessError(error)
        );
    }
}
