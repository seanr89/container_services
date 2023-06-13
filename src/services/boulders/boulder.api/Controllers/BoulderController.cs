using Microsoft.AspNetCore.Mvc;

namespace boulder.api.Controllers;

[ApiController]
[Route("[controller]")]
public class BoulderController : ControllerBase
{
    private readonly ILogger<BoulderController> _logger;
    private readonly BoulderService _boulderService;

    public BoulderController(ILogger<BoulderController> logger,
                             BoulderService boulderService)
    {
        _logger = logger;
        _boulderService = boulderService;
    }

    [HttpGet(Name = "GetBoulders")]
    public IEnumerable<Boulder> Get()
    {
        return _boulderService.GetAllBoulders();
    }
}
