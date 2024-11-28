using Microsoft.EntityFrameworkCore;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Schedules
{
    internal static class ScheduleEntitiesConfigurator
    {
        internal static void ApplyScheduleModelConfiguration(this ModelBuilder modelBuilder)
        {
            new ScheduleEntityConfiguration().Configure(modelBuilder);
        }
    }
}
