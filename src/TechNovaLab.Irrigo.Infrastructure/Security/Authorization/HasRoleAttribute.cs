using Microsoft.AspNetCore.Authorization;

namespace TechNovaLab.Irrigo.Infrastructure.Security.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class HasRoleAttribute(string role) : AuthorizeAttribute(role)
    {
    }
}
