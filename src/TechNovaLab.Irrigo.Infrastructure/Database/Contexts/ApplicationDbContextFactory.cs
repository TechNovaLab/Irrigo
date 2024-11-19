using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Contexts
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=TechNovaLab.Irrigo.v1;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer(connectionString,
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5, 
                        maxRetryDelay: TimeSpan.FromSeconds(10), 
                        errorNumbersToAdd: null);
                });

            return new ApplicationDbContext(optionBuilder.Options);
        }
    }
}
