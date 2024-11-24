using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Users
{
    internal class UserEntityConfiguration : EntityConfiguratorBase<User>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(pk => pk.Id);
                entity.Property(x => x.Id);
            });

            base.Configure(modelBuilder);
        }
    }
}
