using Asp.Versioning;
using Catalog.API.Middlewares;
using Catalog.Application;
using Catalog.Infrastructure;
using Ecart.Core;
using Ecart.Core.Loggers;
using Serilog;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog(SeriLogger.Configure);
builder.Services.AddProblemDetails(options =>
{
    // Customize ProblemDetails
    options.CustomizeProblemDetails = (context) =>
    {
        var problemDetails = context.ProblemDetails;
        context.HttpContext.Response.ContentType = "application/problem+json";
        problemDetails.Instance = $"{context.HttpContext?.Request.Method} {context.HttpContext?.Request.Path}";
        problemDetails.Extensions["traceId"] = Activity.Current?.Id ?? context.HttpContext?.TraceIdentifier;

    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddDaprClient();
builder.Services.AddDaprServices();
await builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddCarter();
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
app.NewVersionedApi()
    .MapGroup("api/v{apiVersion:apiVersion}/")
    .HasApiVersion(1)
    .MapCarter();

app.UseHealthChecks("/healthz");

app.Run();
