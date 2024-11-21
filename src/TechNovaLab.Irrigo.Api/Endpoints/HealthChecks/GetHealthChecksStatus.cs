using MediatR;
using TechNovaLab.Irrigo.Api.Endpoints.Interfaces;

namespace TechNovaLab.Irrigo.Api.Endpoints.HealthChecks
{
    internal sealed class GetHealthChecksStatus : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
        {            
            routeBuilder.MapGet("/health/status", async (ISender sender, CancellationToken cancellatioToken) =>
            {
                return true;
            })
            .AllowAnonymous()
            .WithTags(Tags.HealthChecks);
        }
    }
}
