using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.Histories;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Histories
{
    internal class HistoryEntityConfiguration : EntityConfiguratorBase<History>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("Histories");
                entity.HasKey(pk => pk.Id);

                entity
                    .HasOne(x => x.SprinklerGroup)
                    .WithMany(x => x.Histories)
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
