using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.Restrictions;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Restrictions
{
    internal class RestrictionEntityConfiguration : EntityConfiguratorBase<Restriction>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restriction>(entity =>
            {
                entity.ToTable("Restrictions");
                entity.HasKey(pk => pk.Id);

                entity
                    .Property(c => c.Id)
                    .ValueGeneratedOnAdd();
            });

            base.Configure(modelBuilder);
        }
    }
}
