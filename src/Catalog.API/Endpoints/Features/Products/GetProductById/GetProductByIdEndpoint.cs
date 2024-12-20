﻿using Catalog.API.Endpoints.Core;
using Catalog.Application.Features.Products.GetProductById;

namespace Catalog.API.Endpoints.Features.Products.GetProductById;



public class GetProductByIdEndpoint : EndpointsBase
{
    public override void AddRoutes(IEndpointRouteBuilder app)
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
        var response = await sender.Send(new GetProductByIdQuery(id));

        return response.Match<IResult>
        (
               result => Results.Ok(result),
               error => ProcessError(error)
        );
    }
}
