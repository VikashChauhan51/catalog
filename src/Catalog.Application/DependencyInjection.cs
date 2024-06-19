
using Catalog.Application.Handlers;
using Ecart.Core.Behaviors;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(GetProductsQueryHandler).Assembly;
        // register handlers
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly!);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        //register validators
        services.AddValidatorsFromAssembly(assembly);
        return services;
    }
}
