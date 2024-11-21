using Microsoft.AspNetCore.Authorization;

namespace TechNovaLab.Irrigo.Infrastructure.Security.Authorization
{
    internal sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
    {
        public string Permission { get; } = permission;
    }
}
