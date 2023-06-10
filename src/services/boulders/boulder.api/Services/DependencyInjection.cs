
using Microsoft.EntityFrameworkCore;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BoulderContext>(options =>
            options.UseNpgsql(configuration.GetValue<string>("PostgresSettings:ConnectionString")));

        services.AddTransient<BoulderService>();
        return services;
    }
}