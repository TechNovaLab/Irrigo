using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.SharedKernel.Core;
using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Api.Middleware
{
    public class RequestAuthorizationMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            await next(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized ||
                context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                context.Response.ContentType = "application/json";
                context.Response.Headers.Append("Access-Control-Allow-Origin", context.Request.Headers.Origin);

                var result = context.Response.StatusCode switch
                {
                    StatusCodes.Status401Unauthorized => Result.Failure(
                        new Error(
                            "Unauthorized",
                            "The token is either missing or has expired. Please log in again.",
                            ErrorType.Unauthorized)),

                    StatusCodes.Status403Forbidden => Result.Failure(
                        new Error(
                            "Forbidden",
                            "You do not have the required role or permissions to perform this action.",
                            ErrorType.Forbidden)),

                    _ => Result.Failure(
                        new Error(
                            "Unknown",
                            "An unknown authorization error occurred.",
                            ErrorType.Problem))
                };

                await CustomResults.Problem(result).ExecuteAsync(context);
            }
        }
    }
}
