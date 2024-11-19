using Microsoft.Extensions.Diagnostics.HealthChecks;
using TechNovaLab.Irrigo.Infrastructure.Database.Contexts;

namespace TechNovaLab.Irrigo.Infrastructure.HealthChecks
{
    internal class DatabaseHealthCheck(ApplicationDbContext dbContext) : IHealthCheck
    {        		
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
			try
			{
				await dbContext.Database.CanConnectAsync(cancellationToken);

				return HealthCheckResult.Healthy("Database is operational");
			}
			catch (Exception ex)
			{
				return HealthCheckResult.Unhealthy("Database is not reachable.", ex);
			}
        }
    }
}
