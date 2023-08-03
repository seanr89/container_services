using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]/[action]")]
public class SessionController: ControllerBase
{
    private readonly SessionService _sessionService;

    public SessionController(SessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSession(Session request)
    {
        var session = await _sessionService.CreateSession(request);
        return Ok(session);
    }

    [HttpGet("{sessionId}")]
    public async Task<IActionResult> GetSession(string sessionId)
    {
        var session = await _sessionService.GetSession(sessionId);
        if (session == null)
        {
            return NotFound();
        }
        return Ok(session);
    }

    [HttpDelete("{sessionId}")]
    public async Task<IActionResult> DeleteSession(string sessionId)
    {
        await _sessionService.DeleteSession(sessionId);
        return NoContent();
    }
}