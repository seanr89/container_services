using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables()
                            .Build();

builder.Services.Configure<PostgresSettings>(
                builder.Configuration.GetSection("PostgresSettings"));

//DI Layer
builder.Services.AddApplication(configuration);

//string connectionString = builder.Configuration["PostgresSettings:ConnectionString"];
// Add services to the container.
builder.Services.AddHealthChecks()
.AddCheck<SampleHealthCheck>(
        "Sample",
        failureStatus: HealthStatus.Degraded)
.AddCheck<DbHealthCheck>(
        "DB",
        failureStatus: HealthStatus.Degraded);
// .AddNpgSql(connectionString);

builder.Services.AddControllers();

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

ServiceExtensions.RunDBMigration(builder.Services);

app.MapControllers();

app.Run();
