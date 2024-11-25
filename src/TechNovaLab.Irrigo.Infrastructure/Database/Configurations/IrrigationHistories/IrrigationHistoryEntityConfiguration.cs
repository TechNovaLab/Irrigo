using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.IrrigationHistories;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.IrrigationHistories
{
    internal class IrrigationHistoryEntityConfiguration : EntityConfiguratorBase<IrrigationHistory>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrrigationHistory>(entity =>
            {
                entity.ToTable("IrrigationHistories");
                entity.HasKey(pk => pk.Id);

                entity
                    .HasOne(x => x.SprinklerGroup)
                    .WithMany(x => x.IrrigationHistories)
                    .HasForeignKey(fk => fk.SprinklerGroupId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .Property(x => x.Id)
                    .ValueGeneratedOnAdd();
            });

            base.Configure(modelBuilder);
        }
    }
}
