using Microsoft.Extensions.Diagnostics.HealthChecks;

public class DbHealthCheck : IHealthCheck
{
    internal BoulderContext _context;
    public DbHealthCheck(BoulderContext context)
    {
        _context = context;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var isHealthy = true;

        try{
            isHealthy = await _context.Database.CanConnectAsync();
            if(isHealthy)
            {
                return HealthCheckResult.Healthy("Db is healthy");
            }
            return HealthCheckResult.Unhealthy("Unable to connect to database");
        }
        catch(Exception ex)
        {
            return HealthCheckResult.Unhealthy(exception: ex);
        }
    }
}