using Microsoft.EntityFrameworkCore;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.IrrigationSchedules
{
    internal static class IrrigationScheduleEntitiesConfigurator
    {
        internal static void ApplyIrrigationScheduleModelConfiguration(this ModelBuilder modelBuilder)
        {
            new IrrigationScheduleEntityConfiguration().Configure(modelBuilder);            
        }
    }
}
