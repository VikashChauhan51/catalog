using Catalog.Application.Product.Handlers;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        // Register Akka.NET actor system
        services.AddSingleton(provider =>
        {
            var bootstrap = BootstrapSetup.Create();
            // enable DI support inside this ActorSystem, if needed
            var diSetup = DependencyResolverSetup.Create(provider);
            // merge this setup (and any others) together into ActorSystemSetup
            var actorSystemSetup = bootstrap.And(diSetup);
            var actorSystem = ActorSystem.Create("ProductSystem", actorSystemSetup);
            return actorSystem;
        });
        //register validators
         services.AddValidatorsFromAssembly(assembly);
        return services;
    }
}
