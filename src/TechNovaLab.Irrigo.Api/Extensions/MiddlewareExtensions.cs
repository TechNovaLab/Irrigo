using TechNovaLab.Irrigo.Api.Middleware;

namespace TechNovaLab.Irrigo.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestContextLogging(this IApplicationBuilder app) =>       
            app.UseMiddleware<RequestContextLoggingMiddleware>();

        public static IApplicationBuilder UseRequestAuthorizationMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<RequestAuthorizationMiddleware>();
    }
}
