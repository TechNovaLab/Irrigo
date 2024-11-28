using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.Schedules;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Schedules
{
    internal class ScheduleEntityConfiguration : EntityConfiguratorBase<Schedule>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedules");
                entity.HasKey(pk => pk.Id);

                entity
                    .HasOne(x => x.SprinklerGroup)
                    .WithMany(x => x.Schedules)
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
