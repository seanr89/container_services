public class GroupingService
{
    private readonly BoulderContext _context;

    public GroupingService(BoulderContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Grouping>> GetAllGroupings()
    {
        return await _context.Groupings.ToListAsync();
    }

    public async Task<Grouping?> GetGroupingById(int id)
    {
        return await _context.Groupings.FindAsync(id);
    }

    public async Task<Grouping> AddGrouping(Grouping grouping)
    {
        _context.Groupings.Add(grouping);
        await _context.SaveChangesAsync();

        return grouping;
    }
}