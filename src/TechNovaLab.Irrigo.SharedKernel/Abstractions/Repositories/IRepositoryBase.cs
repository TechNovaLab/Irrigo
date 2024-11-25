using System.Linq.Expressions;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.SharedKernel.Abstractions.Repositories
{
    public interface IRepositoryBase
    {
        ValueTask<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : EntityBase;

        IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>>? predicateExpression = null)
            where TEntity : EntityBase;
    }
}
