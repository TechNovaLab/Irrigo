using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechNovaLab.Irrigo.SharedKernel.Abstractions.Data;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Builders
{
    public class EntityTypeConfigurationBuilder<TEntity>(EntityTypeBuilder<TEntity> entityBuilder) : IEntityTypeConfigurationBuilder<TEntity> where TEntity : EntityBase
    {
        private readonly EntityTypeBuilder<TEntity> entityBuilder = entityBuilder;

        public IEntityTypeConfigurationBuilder<TEntity> HasData(params TEntity[] data)
        {
            entityBuilder.HasData(data);

            return this;
        }

        public IEntityTypeConfigurationBuilder<TEntity> Ignore(string propertyName)
        {
            entityBuilder.Ignore(propertyName);

            return this;
        }

        public IEntityTypeConfigurationBuilder<TEntity> Property<TProperty>(string propertyName)
        {
            entityBuilder.Property<TProperty>(propertyName);

            return this;
        }
    }
}
