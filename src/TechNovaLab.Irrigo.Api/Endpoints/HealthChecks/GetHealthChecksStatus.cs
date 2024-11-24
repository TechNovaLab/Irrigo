using MediatR;

namespace TechNovaLab.Irrigo.Api.Endpoints.HealthChecks
{
    internal sealed class GetHealthChecksStatus : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {            
            app.MapGet("/health/status", async (ISender sender, CancellationToken cancellatioToken) =>
            {
                return true;
            })
            .AllowAnonymous()
            .WithTags(Tags.HealthChecks);
        }
    }
}
