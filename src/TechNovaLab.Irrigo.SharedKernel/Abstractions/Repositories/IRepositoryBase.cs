using TechNovaLab.Irrigo.SharedKernel.Abstractions.Data;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.SharedKernel.Abstractions.Repositories
{
    public interface IRepositoryBase //<IDatabaseContext>
    {
        Task<TEntity?> FindAsync<TEntity, T>(T id, CancellationToken cancellationToken = default)
            where TEntity : EntityBase
            where T : struct;
    }
}
