using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using TechNovaLab.Irrigo.Infrastructure.Security.Authentication;

namespace TechNovaLab.Irrigo.Infrastructure.Security.Authorization
{
    internal sealed class PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory)
    : AuthorizationHandler<PermissionRequirement>
    {
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            // TODO: Rechazar a los usuarios no autenticados aquí.
            if (context.User is not { Identity.IsAuthenticated: true } or { Identity.IsAuthenticated: false })
            {
                // TODO: Eliminar esta llamada cuando se implemente PermissionProvider.GetForUserIdAsync
                //context.Succeed(requirement);

                context.Fail(new AuthorizationFailureReason(this, "User is not authenticated."));

                return;
            }

            using IServiceScope scope = serviceScopeFactory.CreateScope();

            PermissionProvider permissionProvider = scope.ServiceProvider.GetRequiredService<PermissionProvider>();
            Guid userId = context.User.GetUserId();
            HashSet<string> permissions = await permissionProvider.GetForUserIdAsync(userId);

            if (permissions.Contains(requirement.Permission))
            {
                context.Succeed(requirement);

                return;
            }
        }
    }
}
