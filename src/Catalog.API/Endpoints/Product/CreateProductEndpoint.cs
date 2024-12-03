using Catalog.Application.Product.Commands;

namespace Catalog.API.Endpoints.Product;


public record CreateProductRequest(string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);

public record CreateProductResponse(string Id);

public class CreateProductEndpoint : EndpointsBase, ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
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
