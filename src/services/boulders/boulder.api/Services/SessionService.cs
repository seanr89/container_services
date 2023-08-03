public class SessionService
{
    private readonly BoulderContext _context;

    public SessionService(
        BoulderContext context)
    {
        _context = context;
    }

    public async Task<Session> CreateSession(Session session)
    {
        var sessionId = Guid.NewGuid().ToString();
        // var session = new Session
        // {
        //     Id = sessionId,
        //     UserId = request.UserId,
        //     StartTime = DateTime.UtcNow
        // };
        // _sessions.Add(sessionId, session);
        return session;
    }

    public async Task<Session> GetSession(string sessionId)
    {
        // if (_sessions.TryGetValue(sessionId, out var session))
        // {
        //     return session;
        // }
        return null;
    }

    public async Task DeleteSession(string sessionId)
    {
        //_sessions.Remove(sessionId);
    }
}