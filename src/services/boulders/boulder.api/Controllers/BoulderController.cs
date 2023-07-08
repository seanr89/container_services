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
    public async Task<IEnumerable<Boulder>> Get()
    {
        return await _boulderService.GetAllBoulders();
    }

    [HttpGet(Name = "GetBoulderCount")]
    public int GetCount()
    {
        return _boulderService.GetBoulderCount();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Boulder boulder)
    {
        await _boulderService.AddBoulder(boulder);
        return CreatedAtRoute("GetBoulders", new { id = boulder.Id }, boulder);
    }
}
