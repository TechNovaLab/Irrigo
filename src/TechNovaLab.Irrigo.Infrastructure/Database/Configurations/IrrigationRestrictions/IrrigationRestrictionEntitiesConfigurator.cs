using Microsoft.EntityFrameworkCore;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.IrrigationRestrictions
{
    internal static class IrrigationRestrictionEntitiesConfigurator
    {
        internal static void ApplyIrrigationRestrictionsModelConfiguration(this ModelBuilder modelBuilder)
        {
            new IrrigationRestrictionEntityConfiguration().Configure(modelBuilder);
        }
    }
}
