using TechNovaLab.Irrigo.Domain.Entities.Users;

namespace TechNovaLab.Irrigo.Application.Features.UserManagement.Register
{
    public record UserResponse(
        Guid Id,
        string Email,
        string FirstName,
        string LastName,
        Role Role);
}
