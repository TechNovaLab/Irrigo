using Microsoft.EntityFrameworkCore;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Histories
{
    internal static class HistoryEntitiesConfigurator
    {
        internal static void ApplyHistoryModelConfiguration(this ModelBuilder modelBuilder)
        {
            new HistoryEntityConfiguration().Configure(modelBuilder);
        }
    }
}
