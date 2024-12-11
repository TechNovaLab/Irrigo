using Microsoft.EntityFrameworkCore;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Sprinklers
{
    internal static class SprinklerEntitiesConfigurator
    {
        internal static void ApplySprinklersModelConfiguration(this ModelBuilder modelBuilder)
        {
            new SprinklerEntityConfiguration().Configure(modelBuilder);
            new SprinklerGroupEntityConfiguration().Configure(modelBuilder);
        }
    }
}
