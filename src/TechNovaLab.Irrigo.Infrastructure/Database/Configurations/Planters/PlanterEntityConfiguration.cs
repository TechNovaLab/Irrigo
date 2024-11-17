using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.Planters;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Planters
{
    internal class PlanterEntityConfiguration : EntityConfiguratorBase<Planter>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planter>(entity =>
            {
                entity.ToTable("Planters");
                entity.HasKey(pk => pk.Id);
                
                entity
                    .Property(x => x.Id)
                    .ValueGeneratedOnAdd();
            });

            base.Configure(modelBuilder);
        }
    }
}
