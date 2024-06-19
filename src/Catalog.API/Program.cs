using Asp.Versioning;
using Catalog.Application;
using Catalog.Infrastructure;
using Ecart.Core;
using Ecart.Core.Handlers;
using Ecart.Core.Loggers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddDaprClient();
builder.Services.AddDaprServices();
await builder.Services.AddInfrastructureServices(builder.Configuration);
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
