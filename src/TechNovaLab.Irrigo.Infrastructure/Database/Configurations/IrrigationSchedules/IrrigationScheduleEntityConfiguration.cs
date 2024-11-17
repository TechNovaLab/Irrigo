using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.IrrigationSchedules;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.IrrigationSchedules
{
    internal class IrrigationScheduleEntityConfiguration : EntityConfiguratorBase<IrrigationSchedule>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrrigationSchedule>(entity =>
            {
                entity.ToTable("IrrigationSchedules");
                entity.HasKey(pk => pk.Id);

                entity
                    .HasOne(x => x.SprinklerGroup)
                    .WithMany(x => x.IrrigationSchedules)
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
