using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using TechNovaLab.Irrigo.Api.Configurations;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Application.Configurations;
using TechNovaLab.Irrigo.Infrastructure.Configurations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddSwaggerGenWithAuth(builder.Configuration)
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);

WebApplication app = builder.Build();

app.MapEndpoints(app.MapGroup("/api"));

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUI();
    app.ApplyMigrations();
}

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseRequestContextLogging();
app.UseSerilogRequestLogging();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

await app.RunAsync();
