using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.SharedKernel.Abstractions.Data
{
    public interface IModelBuilder
    {
        IEntityTypeConfigurationBuilder<TEntity> Entity<TEntity>() where TEntity : EntityBase;
    }
}
