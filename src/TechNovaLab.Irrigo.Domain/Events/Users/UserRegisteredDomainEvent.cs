using TechNovaLab.Irrigo.SharedKernel.Events;

namespace TechNovaLab.Irrigo.Domain.Events.Users
{
    public sealed record UserRegisteredDomainEvent(Guid UserId) : IDomainEvent;
}
