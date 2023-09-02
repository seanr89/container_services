namespace boulder.api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class BoulderController : ControllerBase
{
    private readonly ILogger<BoulderController> _logger;
    private readonly BoulderService _boulderService;

    public BoulderController(ILogger<BoulderController> logger,
                             BoulderService boulderService)
    {
        ArgumentNullException.ThrowIfNull(logger, "logger");
        ArgumentNullException.ThrowIfNull(boulderService, "boulderService");
        _logger = logger;
        _boulderService = boulderService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(IEnumerable<Boulder>), 200)]
    [HttpGet(Name = "GetBoulders")]
    public async Task<IEnumerable<Boulder>> Get()
    {
        return await _boulderService.GetAllBoulders();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(int), 200)]
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
