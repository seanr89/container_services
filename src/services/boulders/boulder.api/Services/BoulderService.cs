public class BoulderService
{
    internal readonly BoulderContext _context;
    public BoulderService(BoulderContext context)
    {
        this._context = context;
    }

    /// <summary>
    /// Simple query to get the count of boulders
    /// </summary>
    /// <returns></returns>
    public int GetBoulderCount() => _context.Boulders.Count();

    public async Task<IEnumerable<Boulder>> GetAllBoulders() => await _context.Boulders.ToListAsync();

    public async Task<int> AddBoulder(Boulder boulder) {
        await _context.Boulders.AddAsync(boulder);
        var res = await _context.SaveChangesAsync();
        return res;
    }
}