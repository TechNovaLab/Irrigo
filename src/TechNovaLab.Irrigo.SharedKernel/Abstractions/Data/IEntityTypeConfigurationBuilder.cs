using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.SharedKernel.Abstractions.Data
{
    public interface IEntityTypeConfigurationBuilder<TEntity> where TEntity : EntityBase
    {
        IEntityTypeConfigurationBuilder<TEntity> HasData(params TEntity[] data);
        IEntityTypeConfigurationBuilder<TEntity> Property<TProperty>(string propertyName);
        IEntityTypeConfigurationBuilder<TEntity> Ignore(string propertyName);
    }
}
