using MediatR;
using TechNovaLab.Irrigo.Domain.Events.Users;

namespace TechNovaLab.Irrigo.Application.Features.UserManagement.Register
{
    internal sealed class UserRegisteredDomainEventHandler : INotificationHandler<UserRegisteredDomainEvent>
    {
        public Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Send an email verification link, etc.
            return Task.CompletedTask;
        }
    }
}
