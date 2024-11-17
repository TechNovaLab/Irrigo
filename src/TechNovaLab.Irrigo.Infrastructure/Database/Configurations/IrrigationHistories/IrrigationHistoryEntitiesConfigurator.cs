using Microsoft.EntityFrameworkCore;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.IrrigationHistories
{
    internal static class IrrigationHistoryEntitiesConfigurator
    {
        internal static void ApplyIrrigationHistoryModelConfiguration(this ModelBuilder modelBuilder)
        {
            new IrrigationHistoryEntityConfiguration().Configure(modelBuilder);
        }
    }
}
