using TechNovaLab.Irrigo.SharedKernel.Abstractions.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Abstractions
{
    public abstract class RepositoryBase(DbContextBase context) : IRepositoryBase //<DbContextBase>
    {
        public DbContextBase Context => context ?? throw new NotImplementedException();

        public async Task<TEntity?> FindAsync<TEntity, TKey>(TKey id, CancellationToken cancellationToken = default)
           where TEntity : EntityBase
           where TKey : struct
        {
            return await Context.Set<TEntity>().FindAsync([id], cancellationToken);
        }
    }
}
