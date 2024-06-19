using Catalog.Infrastructure.Helpers;
using Dapr.Client;
using Ecart.Core;
using Ecart.Core.Configurations;
using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Catalog.Infrastructure;
public static class DependencyInjection
{
    public static async Task<IServiceCollection> AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDaprConfiguration(configuration);
        services.AddSqlConfiguration(configuration);

        var daprConfig = services.BuildServiceProvider().GetRequiredService<IOptions<DaprConfig>>().Value;
        var sqlConfig = services.BuildServiceProvider().GetRequiredService<IOptions<SqlConfig>>().Value;
        var daprClient = services.BuildServiceProvider().GetRequiredService<DaprClient>();

        await daprClient.WaitForSidecarAsync();
        var secretKeys = await daprClient.GetSecretAsync(daprConfig.SecretstoreName, Constants.DatabaseCredentialsKey);
        var credentials = secretKeys[Constants.DatabaseCredentialsKey];

        var connectionString = new ConnectionStringBuilder()
            .WithServer(sqlConfig.ServerName)
            .WithPort(sqlConfig.ServerPort)
            .WithDatabase(sqlConfig.DatabaseName)
            .WithCredentials(credentials)
            .Build();

        services.AddMarten(opts =>
        {
            opts.Connection(connectionString);
        }).UseLightweightSessions();

        services
            .AddHealthChecks()
            .AddNpgSql(connectionString);

        return services;
    }
}
