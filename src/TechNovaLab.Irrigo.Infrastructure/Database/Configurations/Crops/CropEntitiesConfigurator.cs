using Microsoft.EntityFrameworkCore;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Crops
{
    internal static class CropEntitiesConfigurator
    {
        internal static void ApplyCropsModelConfiguration(this ModelBuilder modelBuilder)
        {
            new CropEntityConfiguration().Configure(modelBuilder);
            new CropTypeEntityConfiguration().Configure(modelBuilder);
        }
    }
}
