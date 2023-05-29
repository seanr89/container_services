using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHealthChecks()
.AddCheck<SampleHealthCheck>(
        "Sample",
        failureStatus: HealthStatus.Degraded);

// Registers required services for health checks
builder.Services.AddHealthChecksUI(setupSettings: setup =>
{
    setup.SetEvaluationTimeInSeconds(15); // Configures the UI to poll for healthchecks updates every 5 seconds
}
).AddInMemoryStorage();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

      // {
      //   "Name": "Ordering HTTP Check",
      //   "Uri": "http://host.docker.internal:5102/hc"
      // },
      // {
      //   "Name": "Ordering HTTP Background Check",
      //   "Uri": "http://host.docker.internal:5111/hc"
      // }

// build the app, register other middleware
app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");

app.MapControllers();

app.Run();
