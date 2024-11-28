using Microsoft.EntityFrameworkCore;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Restrictions
{
    internal static class RestrictionEntitiesConfigurator
    {
        internal static void ApplyRestrictionsModelConfiguration(this ModelBuilder modelBuilder)
        {
            new RestrictionEntityConfiguration().Configure(modelBuilder);
        }
    }
}
