using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TechNovaLab.Irrigo.Domain.Entities.Users;

namespace TechNovaLab.Irrigo.Infrastructure.Security.Authorization
{
    internal class RoleAndPermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : DefaultAuthorizationPolicyProvider(options)
    {
        private readonly AuthorizationOptions authorizationOptions = options.Value;

        public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            AuthorizationPolicy? policy = await base.GetPolicyAsync(policyName);

            if (policy is not null)
            {
                return policy;
            }

            if (Enum.TryParse<Role>(policyName, out var requiredRole))
            {
                AuthorizationPolicy rolePolicy = new AuthorizationPolicyBuilder()
                    .RequireAssertion(context =>
                    {
                        var userRoleClaim = context.User.FindFirst(ClaimTypes.Role)?.Value;

                        if (Enum.TryParse(userRoleClaim, out Role userRole))
                        {
                            return userRole >= requiredRole;
                        }

                        return false;
                    })
                    .Build();

                authorizationOptions.AddPolicy(policyName, rolePolicy);

                return rolePolicy;
            }

            AuthorizationPolicy permissionPolicy = new AuthorizationPolicyBuilder()
                .AddRequirements(new PermissionRequirement(policyName))
                .Build();

            authorizationOptions.AddPolicy(policyName, permissionPolicy);

            return permissionPolicy;
        }
    }
}
