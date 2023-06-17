using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
.AddCheck<SampleHealthCheck>(
        "Sample",
        failureStatus: HealthStatus.Degraded);

builder.Services.AddHealthChecksUI(setupSettings: setup =>
    {
        setup.DisableDatabaseMigrations();
        setup.SetEvaluationTimeInSeconds(15); // Configures the UI to poll for healthchecks updates every 5 seconds
    }
).AddInMemoryStorage();

var app = builder.Build();

app.MapHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

// build the app, register other middleware
app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");

#region Min-Endpoints

// Basic Test Endpoint! (Hello)
app.MapGet("/hello", () => "Hello World!");

#endregion

app.Run();
