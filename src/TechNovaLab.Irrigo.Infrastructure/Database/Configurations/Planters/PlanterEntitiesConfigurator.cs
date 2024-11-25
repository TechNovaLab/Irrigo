using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Crops;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Planters
{
    internal static class PlanterEntitiesConfigurator
    {
        internal static void ApplyPlantersModelConfiguration(this ModelBuilder modelBuilder)
        {
            new CropEntityConfiguration().Configure(modelBuilder);
            new CropTypeEntityConfiguration().Configure(modelBuilder);
        }
    }
}
