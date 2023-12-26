using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class LocationController : ControllerBase
{
    private readonly ILogger<LocationController> _logger;
    private readonly LocationService _locationService;

    public LocationController(ILogger<LocationController> logger,
                                LocationService locationService)
    {
        ArgumentNullException.ThrowIfNull(logger, "logger");
        ArgumentNullException.ThrowIfNull(locationService, "locationService");
        _logger = logger;
        _locationService = locationService;
    }

    /// <summary>
    /// Handle get for all location records
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(IEnumerable<LocationListDTO>), 200)]
    [HttpGet]
    public async Task<IEnumerable<LocationListDTO>> Get()
    {
        var data = await _locationService.GetAllLocations();
        // Run DTO Conversion!
        if (data.Any())
        {
            var dtos = data.Select(x => new LocationListDTO(x));
            return dtos;
        }
        return Enumerable.Empty<LocationListDTO>();
    }

    /// <summary>
    /// Get Single Location by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LocationDTO), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Support creation of a new a location
    /// </summary>
    /// <param name="location">DTO Creation object</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<LocationDTO>> Create(CreateLocationDTO location)
    {
        var locationModel = location.ToLocation(location);

        await _locationService.CreateLocation(locationModel);

        var locationDTO = new LocationDTO(locationModel);

        return CreatedAtAction(nameof(GetById), new { id = locationDTO.Id }, locationDTO);
    }

    /// <summary>
    /// Update an individual location
    /// </summary>
    /// <param name="id"></param>
    /// <param name="location"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Location location)
    {
        if (id != location.Id)
            return this.BadRequest();

        await _locationService.UpdateLocation(location);

        return this.NoContent();
    }

    /// <summary>
    /// Delete an individual location
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<IActionResult> Delete(int id)
    {
        var location = await _locationService.GetLocationById(id);

        if (location == null)
        {
            return this.NotFound();
        }

        await _locationService.DeleteLocation(location);

        return this.NoContent();
    }
}