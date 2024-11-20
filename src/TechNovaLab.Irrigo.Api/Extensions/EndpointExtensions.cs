using TechNovaLab.Irrigo.Api.Endpoints.Interfaces;

namespace TechNovaLab.Irrigo.Api.Extensions
{
    public static class EndpointExtensions
    {
        public static IApplicationBuilder MapEndpoints(
            this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
        {
            IEnumerable<IEndpoint> endpoints = app.Services
                .GetRequiredService<IEnumerable<IEndpoint>>();

            IEndpointRouteBuilder builder = routeGroupBuilder is null 
                ? app 
                : routeGroupBuilder;

            foreach (IEndpoint endpoint in endpoints)
            {
                endpoint.MapEndpoint(builder);
            }

            return app;
        }
    }
}
