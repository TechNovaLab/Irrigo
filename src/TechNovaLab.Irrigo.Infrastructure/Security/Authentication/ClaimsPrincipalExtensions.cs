using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace TechNovaLab.Irrigo.Infrastructure.Security.Authentication
{
    public static partial class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal? claimsPrincipal)
        { 
            string? userId = claimsPrincipal?.FindFirstValue(ClaimTypes.NameIdentifier);

            return Guid.TryParse(userId, out Guid parsedUserId) 
                ? parsedUserId 
                : throw new ApplicationException("User id is unavailable.");
        }
    }
}
