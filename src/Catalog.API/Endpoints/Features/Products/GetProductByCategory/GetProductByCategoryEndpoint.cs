using Catalog.API.Endpoints.Core;
using Catalog.Application.Features.Products.GetProductByCategory;

namespace Catalog.API.Endpoints.Features.Products.GetProductByCategory;



public class GetProductByCategoryEndpoint : EndpointsBase
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/product/{category}/category",
            GetByCategory)
        .WithName("GetProductByCategory")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Category")
        .WithDescription("Get Product By Category");
    }

    private static async Task<IResult> GetByCategory(string category, ISender sender)
    {
        var response = await sender.Send(new GetProductByCategoryQuery(category));

        return response.Match<IResult>
        (
               result => Results.Ok(result),
               error => ProcessError(error)
        );
    }

}
