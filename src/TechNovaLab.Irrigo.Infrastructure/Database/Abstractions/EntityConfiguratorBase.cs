using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Abstractions
{
    public abstract class EntityConfiguratorBase<TEntity> : IEntityConfigurator where TEntity : EntityBase
    {
        public IEnumerable<TEntity> InitialData { get; set; } = default!;

        public virtual bool ApplySeed { get; set; }

        protected EntityConfiguratorBase()
        {
            ApplySeed = false;
        }

        public virtual void Configure(ModelBuilder modelBuilder)
        {

        }

        public virtual void Seed(ModelBuilder modelBuilder)
        {
            if (ApplySeed && InitialData != null && InitialData.Any())
            {
                modelBuilder.Entity<TEntity>().HasData(InitialData.ToArray());
            }
        }
    }
}
