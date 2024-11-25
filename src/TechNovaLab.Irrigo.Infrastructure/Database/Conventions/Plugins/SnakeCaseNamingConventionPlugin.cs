using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System.Diagnostics;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Conventions.Plugins
{
    internal class SnakeCaseNamingConventionPlugin : IConventionSetPlugin
    {
        public ConventionSet ModifyConventions(ConventionSet conventionSet)
        {
            Console.WriteLine("Applying SnakeCase conventions");
            Debug.Print("Applying SnakeCase conventions");
            conventionSet.ModelFinalizingConventions.Add(new SnakeCaseNamingConvention());
            return conventionSet;
        }
    }
}
