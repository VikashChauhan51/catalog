using Catalog.Application.Product.Queries;

namespace Catalog.API.Endpoints.Product;

public record GetProductByIdResponse(ProductDto Product);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}/product", GetById)
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }

    private static async Task<IResult> GetById(string id, ISender sender)
    {
        var result = await sender.Send(new GetProductByIdQuery(id));

        var response = result.Adapt<GetProductByIdResponse>();

        return Results.Ok(response);
    }
}
