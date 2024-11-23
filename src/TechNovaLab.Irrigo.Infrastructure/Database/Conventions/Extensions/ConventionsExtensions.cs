using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using TechNovaLab.Irrigo.Infrastructure.Database.Conventions.Plugins;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Conventions.Extensions
{
    public static class ConventionsExtensions
    {
        public static DbContextOptionsBuilder UseSnakeCaseNamingConvention(this DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ReplaceService<IConventionSetPlugin, SnakeCaseNamingConventionPlugin>();
            return optionsBuilder;
        }
    }
}
