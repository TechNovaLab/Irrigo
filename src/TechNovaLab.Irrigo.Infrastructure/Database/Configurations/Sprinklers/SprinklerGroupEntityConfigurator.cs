using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Sprinklers
{
    internal class SprinklerGroupEntityConfigurator : EntityConfiguratorBase<SprinklerGroup>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SprinklerGroup>(entity =>
            {
                entity.ToTable("SprinklerGroups");
                entity.HasKey(pk => pk.Id);

                entity
                    .HasMany(x => x.Crops)
                    .WithOne(x => x.SprinklerGroup)
                    .HasForeignKey(fk => fk.SprinklerGroupId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasMany(x => x.Sprinklers)
                    .WithOne(x => x.SprinklerGroup)
                    .HasForeignKey(fk => fk.SprinklerGroupId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasMany(x => x.IrrigationHistories)
                    .WithOne(x => x.SprinklerGroup)
                    .HasForeignKey(fk => fk.SprinklerGroupId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasMany(x => x.IrrigationSchedules)
                    .WithOne(x => x.SprinklerGroup)
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
