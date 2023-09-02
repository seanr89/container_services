using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class GroupingController : ControllerBase
{
    private readonly GroupingService _service;

    public GroupingController(GroupingService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Grouping>> GetAllGroupings()
    {
        return await _service.GetAllGroupings();
    }

    [HttpGet("{id}")]
    public async Task<IEnumerable<Grouping>> GetGroupingsByd(int id)
    {
        throw new NotImplementedException();
        //return await _service.GetGroupingsByLocationId(locationId);
    }

    [HttpPost]
    public async Task<ActionResult<Grouping>> AddGrouping(Grouping grouping)
    {
        var addedGrouping = await _service.AddGrouping(grouping);

        return CreatedAtAction(nameof(GetGroupingById), new { id = addedGrouping.Id }, addedGrouping);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Grouping>> GetGroupingById(Guid id)
    {
        var grouping = await _service.GetGroupingById(id);

        if (grouping == null)
        {
            return NotFound();
        }

        return grouping;
    }
}