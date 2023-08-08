using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]/[action]")]
public class LocationController : ControllerBase
{
    private readonly ILogger<LocationController> _logger;
    private readonly LocationService _locationService;

    public LocationController(ILogger<LocationController> logger,
                                LocationService locationService)
    {
        _logger = logger;
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<IEnumerable<LocationListDTO>> Get()
    {
        //return await _locationService.GetAllLocations();
        var data = await _locationService.GetAllLocations();
        if(data.Any())
        {
            var dtos = data.Select(x => new LocationListDTO(x));
            return dtos;
        }
        return Enumerable.Empty<LocationListDTO>();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LocationDTO>> GetById(int id)
    {
        var location = await _locationService.GetLocationById(id);

        if (location == null)
        {
            return NotFound();
        }
        var locationDTO = new LocationDTO(location);

        return locationDTO;
    }

    [HttpPost]
    public async Task<ActionResult<LocationDTO>> Create(CreateLocationDTO location)
    {
        var locationModel = location.ToLocation(location);

        await _locationService.CreateLocation(locationModel);

        var locationDTO = new LocationDTO(locationModel);

        return CreatedAtAction(nameof(GetById), new { id = locationDTO.Id }, locationDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Location location)
    {
        if (id != location.Id)
        {
            return BadRequest();
        }

        await _locationService.UpdateLocation(location);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var location = await _locationService.GetLocationById(id);

        if (location == null)
        {
            return NotFound();
        }

        await _locationService.DeleteLocation(location);

        return NoContent();
    }
}