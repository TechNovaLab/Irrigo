using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Crops
{
    internal class CropTypeEntityConfiguration : EntityConfiguratorBase<CropType>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CropType>(entity =>
            {
                entity.ToTable("CropTypes");
                entity.HasKey(pk => pk.Id);

                entity
                    .HasMany(x => x.Crops)
                    .WithOne(x => x.CropType)
                    .HasForeignKey(fk => fk.CropTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .Property(x => x.Id)
                    .ValueGeneratedOnAdd();
            });

            base.Configure(modelBuilder);
        }
    }
}
