using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TechNovaLab.Irrigo.Infrastructure.Database.Conventions.Extensions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Contexts
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            string connectionString = "Host=localhost;Port=5432;Database=irrigo-db;Username=postgres;Password=postgres;Include Error Detail=true";
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            
            optionBuilder
                .UseNpgsql(connectionString, sqlOptions => 
                    sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly))
                .UseSnakeCaseNamingConvention();

            return new ApplicationDbContext(optionBuilder.Options);
        }
    }
}
