using Asp.Versioning;
using Catalog.API;
using Catalog.API.Helpers;
using Dapr.Client;
using Ecart.Core;
using Ecart.Core.Behaviors;
using Ecart.Core.Configurations;
using Ecart.Core.Handlers;
using Ecart.Core.Loggers;
using Marten;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog(SeriLogger.Configure);
builder.Services.AddDaprConfiguration(builder.Configuration);
builder.Services.AddSqlConfiguration(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));

});

builder.Services.AddDaprClient();
builder.Services.AddDaprServices(builder.Configuration);


#pragma warning disable ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
var daprConfig = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<DaprConfig>>().Value;
var sqlConfig = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<SqlConfig>>().Value;
var daprClient = builder.Services.BuildServiceProvider().GetRequiredService<DaprClient>();
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'

await daprClient.WaitForSidecarAsync();
var secretKeys = await daprClient.GetSecretAsync(daprConfig.SecretstoreName, Constants.DatabaseCredentialsKey);
var credentials = secretKeys[Constants.DatabaseCredentialsKey];

var connectionString = new ConnectionStringBuilder()
    .WithServer(sqlConfig.ServerName)
    .WithPort(sqlConfig.ServerPort)
    .WithDatabase(sqlConfig.DatabaseName)
    .WithCredentials(credentials)
    .Build();

builder.Services.AddMarten(opts =>
{
    opts.Connection(connectionString);
}).UseLightweightSessions();


builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1.0);
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});



builder.Services
   .AddHealthChecks()
    .AddNpgSql(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler(options => { });

// Configure the HTTP request pipeline.
app.NewVersionedApi()
    .MapGroup("api/v{apiVersion:apiVersion}/")
    .HasApiVersion(1)
    .MapCarter();

app.UseHealthChecks("/healthz");

app.Run();
