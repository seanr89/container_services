using Microsoft.AspNetCore.Mvc;

namespace boulder.api.Controllers;

[ApiController]
[Route("[controller]")]
public class BoulderController : ControllerBase
{
    private readonly ILogger<BoulderController> _logger;

    public BoulderController(ILogger<BoulderController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetBoulders")]
    public IEnumerable<Boulder> Get()
    {
        throw new NotImplementedException();
        // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        // {
        //     Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //     TemperatureC = Random.Shared.Next(-20, 55),
        //     Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        // })
        // .ToArray();
    }
}
