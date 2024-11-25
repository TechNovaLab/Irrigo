using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.IrrigationRestrictions;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.IrrigationRestrictions
{
    internal class IrrigationRestrictionEntityConfiguration : EntityConfiguratorBase<IrrigationRestriction>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrrigationRestriction>(entity =>
            {
                entity.ToTable("IrrigationRestrictions");
                entity.HasKey(pk => pk.Id);

                entity
                    .Property(c => c.Id)
                    .ValueGeneratedOnAdd();
            });

            base.Configure(modelBuilder);
        }
    }
}
