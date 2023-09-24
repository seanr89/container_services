
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    internal readonly UserService _service;
    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _service.GetAll();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(int id)
    {
        var data = await _service.GetById(id);

        if (data == null)
        {
            return NotFound();
        }
        return this.Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult<User>> Add(User user)
    {
        //var addedGrouping = await _service.AddGrouping(grouping);

        //return CreatedAtAction(nameof(GetGroupingById), new { id = addedGrouping.Id }, addedGrouping);
        throw new NotImplementedException();
    }
}