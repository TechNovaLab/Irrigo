using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.UserManagement.Register
{
    public sealed record RegisterUserCommand(
        string Email, 
        string FirstName, 
        string LastName, 
        string Password) : ICommand<Guid>;
}
