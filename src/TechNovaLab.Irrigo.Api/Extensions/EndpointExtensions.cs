using TechNovaLab.Irrigo.Api.Endpoints;
using TechNovaLab.Irrigo.Domain.Entities.Users;

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

        public static RouteHandlerBuilder HasRole(this RouteHandlerBuilder app, Role role) =>
            app.RequireAuthorization(policy => policy.RequireRole(role.ToString()));

        public static RouteHandlerBuilder HasPermission(this RouteHandlerBuilder app, string permission) =>
            app.RequireAuthorization(permission);
    }
}
