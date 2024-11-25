using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.UserManagement.GetByEmail
{
    public sealed record GetUserByEmailQuery(string Email) : IQuery<UserResponse>;
}
