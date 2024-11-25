using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using TechNovaLab.Irrigo.SharedKernel.Abstractions.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Abstractions
{
    public abstract class RepositoryBase(DbContextBase context) : IRepositoryBase
    {
        public DbContextBase Context => context ?? throw new ArgumentNullException(nameof(context));

        public async ValueTask<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : EntityBase
        {
            var result = await Context
                .Set<TEntity>()
                .AddAsync(entity, cancellationToken);

            return result.Entity;
        }

        public IQueryable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>>? predicateExpression = null) where TEntity : EntityBase
        {
            IQueryable<TEntity> result = Context.Set<TEntity>();

            if (predicateExpression != null)
            {
                result = result.Where(predicateExpression);
            }

            return result;
        }
    }
}
