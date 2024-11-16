using TechNovaLab.Irrigo.SharedKernel.Abstractions.Data;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Builders
{
    public abstract class EntityConfigurator<TEntity> : IEntityConfigurator where TEntity : EntityBase
    {
        public IEnumerable<TEntity> InitialData { get; set; } = default!;
        public virtual bool ApplySeed { get; set; }

        protected EntityConfigurator()
        {
            ApplySeed = false;
        }

        public virtual void Configure(IModelBuilder modelBuilder)
        {

        }

        public virtual void Seed(IModelBuilder modelBuilder)
        {
            if (ApplySeed && InitialData != null && InitialData.Any())
            {
                modelBuilder.Entity<TEntity>().HasData(InitialData.ToArray());
            }
        }
    }

}
