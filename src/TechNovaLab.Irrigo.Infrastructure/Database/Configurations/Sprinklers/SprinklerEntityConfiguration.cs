using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Sprinklers
{
    internal class SprinklerEntityConfiguration : EntityConfiguratorBase<Sprinkler>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sprinkler>(entity =>
            {
                entity.ToTable("Sprinklers");
                entity.HasKey(pk => pk.Id);

                entity
                    .HasOne(x => x.SprinklerGroup)
                    .WithMany(x => x.Sprinklers)
                    .HasForeignKey(fk => fk.SprinklerGroupId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .Property(c => c.Id)
                    .ValueGeneratedOnAdd();
            });

            base.Configure(modelBuilder);
        }
    }
}
