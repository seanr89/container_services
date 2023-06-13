
public class BoulderService
{
    internal readonly BoulderContext _context;
    public BoulderService(BoulderContext context)
    {
        _context = context;
    }

    public int GetBoulderCount()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Boulder> GetAllBoulders()
    {
        throw new NotImplementedException();
    }
}