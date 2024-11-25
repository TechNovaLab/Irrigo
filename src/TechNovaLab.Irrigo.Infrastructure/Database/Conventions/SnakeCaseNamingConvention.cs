using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Text.RegularExpressions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Conventions
{
    internal class SnakeCaseNamingConvention : IModelFinalizingConvention
    {
        public void ProcessModelFinalizing(
            IConventionModelBuilder modelBuilder, 
            IConventionContext<IConventionModelBuilder> context)
        {
            foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
            {
                string tableName = entityType.GetTableName()!;
                entityType.SetTableName(ConvertToSnakeCase(tableName));

                foreach (var property in entityType.GetProperties())
                {
                    var columnName = property.GetColumnName();
                    property.SetColumnName(ConvertToSnakeCase(columnName));
                }
            }
        }

        private static string ConvertToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}
