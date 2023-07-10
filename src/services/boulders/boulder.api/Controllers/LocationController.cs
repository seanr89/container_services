using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IEnumerable<Location>> Get()
        {
            return await _locationService.GetAllLocations();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetById(int id)
        {
            var location = await _locationService.GetLocationById(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        [HttpPost]
        public async Task<ActionResult<Location>> Create(Location location)
        {
            await _locationService.CreateLocation(location);

            return CreatedAtAction(nameof(GetById), new { id = location.Id }, location);
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
}