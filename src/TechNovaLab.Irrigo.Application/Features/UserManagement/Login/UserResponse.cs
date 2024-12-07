using TechNovaLab.Irrigo.Domain.Entities.Users;

namespace TechNovaLab.Irrigo.Application.Features.UserManagement.Login
{
    public record UserResponse(
        Guid Id,
        string Email,
        string FirstName,
        string LastName,
        Role Role,
        string Token);
}
