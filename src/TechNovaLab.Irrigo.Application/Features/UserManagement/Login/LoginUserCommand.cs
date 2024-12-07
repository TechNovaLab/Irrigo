using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.UserManagement.Login
{
    public sealed record LoginUserCommand(
        string Email, 
        string Password) : ICommand<UserResponse>;
}
