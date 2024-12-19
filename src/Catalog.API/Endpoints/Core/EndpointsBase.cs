using Ecart.Core.Exceptions;
using MediatorForge.CQRS.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Endpoints.Core;

public abstract class EndpointsBase : CarterModule
{
    public static IResult ProcessError(Exception error)
    {
        return error switch
        {
            ValidationException validationException => Results.Problem(new ValidationProblemDetails
            {
                Title = validationException.Message,
                Status = 400,
                Errors = validationException.Errors
                .GroupBy(x => x.PropertyName).
                ToDictionary(
                    g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToArray())
            }),
            NotFoundException notFound => Results.NotFound(notFound),
            AuthorizationException => Results.Forbid(),
            UnauthorizedAccessException => Results.Challenge(),
            TooManyRequestsException => Results.StatusCode(429),
            BadRequestException badRequestException => Results.BadRequest(badRequestException),
            _ => Results.BadRequest(error)
        };
    }
}
