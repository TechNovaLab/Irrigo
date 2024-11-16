using TechNovaLab.Irrigo.SharedKernel.Events;

namespace TechNovaLab.Irrigo.SharedKernel.Core
{
    public abstract class EntityBase
    {
        private readonly List<IDomainEvent> domainEvents = [];

        public List<IDomainEvent> DomainEvents => [.. domainEvents];

        public void ClearDomainEvents()
        {
            domainEvents.Clear();
        }

        public void Raise(IDomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }
    }
}
