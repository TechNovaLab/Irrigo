using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Runtime.ExceptionServices;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Infrastructure.Database.Contexts;
using TechNovaLab.Irrigo.SharedKernel.Core;
using TechNovaLab.Irrigo.SharedKernel.Events;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Repositories
{
    public class UnitOfWork(ApplicationDbContext context, IPublisher publisher) : IUnitOfWork
    {
        public async Task<IDbContextTransaction> BeginTransactionAsync()
            => await context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync(IDbContextTransaction transaction, CancellationToken cancellationToken = default)
            => await transaction.CommitAsync(cancellationToken);

        public async Task RollbackTransactionAsync(IDbContextTransaction transaction, CancellationToken cancellationToken = default)
            => await transaction.RollbackAsync(cancellationToken);

        public async Task<int> CompleteAsync(CancellationToken cancellation = default)
            => await context.SaveChangesAsync(cancellation);

        public async Task<bool> CreateExecutionStrategyAsync(Func<Task> operation, CancellationToken cancellationToken = default)
        {
            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await BeginTransactionAsync();

                try
                {
                    await operation();
                    await CommitTransactionAsync(transaction, cancellationToken);
                    await PublishDomainEventsAsync();

                    return true;
                }
                catch (Exception e)
                {
                    await this.RollbackTransactionAsync(transaction, cancellationToken);
                    ExceptionDispatchInfo.Capture(e).Throw();
                    throw;
                }
            });

            return false;
        }

        private async Task PublishDomainEventsAsync()
        {
            var domainEvents = context.ChangeTracker
                .Entries<EntityBase>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    List<IDomainEvent> domainEvents = entity.DomainEvents;

                    entity.ClearDomainEvents();

                    return domainEvents;
                })
                .ToList();

            foreach (IDomainEvent domainEvent in domainEvents)
            {
                await publisher.Publish(domainEvent);
            }
        }
    }
}
