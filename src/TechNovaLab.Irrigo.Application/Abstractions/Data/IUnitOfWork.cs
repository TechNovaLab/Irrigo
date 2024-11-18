using Microsoft.EntityFrameworkCore.Storage;

namespace TechNovaLab.Irrigo.Application.Abstractions.Data
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync(CancellationToken cancellation = default);
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task RollbackTransactionAsync(IDbContextTransaction transaction, CancellationToken cancellationToken);
        Task CommitTransactionAsync(IDbContextTransaction transaction, CancellationToken cancellationToken);
        Task<bool> CreateExecutionStrategyAsync(Func<Task> operation, CancellationToken cancellationToken = default);
    }
}
