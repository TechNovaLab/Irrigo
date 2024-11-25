using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Crops
{
    internal class CropEntityConfiguration : EntityConfiguratorBase<Crop>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crop>(entity =>
            {
                entity.ToTable("Crops");
                entity.HasKey(pk => pk.Id);

                entity
                    .HasOne(x => x.CropType)
                    .WithMany(x => x.Crops)
                    .HasForeignKey(fk => fk.CropTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(x => x.Planter)
                    .WithMany(x => x.Crops)
                    .HasForeignKey(fk => fk.PlanterId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(x => x.SprinklerGroup)
                    .WithMany(x => x.Crops)
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
