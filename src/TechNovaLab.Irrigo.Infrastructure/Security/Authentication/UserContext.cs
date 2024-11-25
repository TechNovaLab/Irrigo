using Microsoft.AspNetCore.Http;
using TechNovaLab.Irrigo.Application.Abstractions.Authentication;

namespace TechNovaLab.Irrigo.Infrastructure.Security.Authentication
{
    public static partial class ClaimsPrincipalExtensions
    {
        internal sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
        {
            public Guid UserId => httpContextAccessor.HttpContext?.User.GetUserId() ??
                throw new ApplicationException("User context is unavailable.");
        }
    }
}
