using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.SharedKernel.Abstractions.Data;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Builders
{
    public class ModelConfigurationBuilder(ModelBuilder modelBuilder) : IModelBuilder
    {
        private readonly ModelBuilder modelBuilder = modelBuilder;

        public IEntityTypeConfigurationBuilder<TEntity> Entity<TEntity>() where TEntity : EntityBase
        {
            return new EntityTypeConfigurationBuilder<TEntity>(modelBuilder.Entity<TEntity>());
        }
    }
}
