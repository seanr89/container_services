public class BoulderService
{
    internal readonly BoulderContext _context;
    public BoulderService(BoulderContext context) => _context = context;

    /// <summary>
    /// Simple query to get the count of boulders
    /// </summary>
    /// <returns></returns>
    public int GetBoulderCount() => _context.Boulders.Count();

    /// <summary>
    /// Retrieves a collection of boulders based on the specified date.
    /// </summary>
    /// <param name="date">The date to filter the boulders by.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of boulders.</returns>
    public async Task<IEnumerable<Boulder>> GetBouldersByDate(DateTime date) =>
        await _context.Boulders.Where(b => b.ActiveDate >= date && b.DeActiveDate <= date).ToListAsync();

    public async Task<IEnumerable<Boulder>> GetAllBoulders() => await _context.Boulders.ToListAsync();

    public async Task<Boulder> GetBoulderById(Guid id) => await _context.Boulders.FindAsync(id);

    /// <summary>
    /// Adds a new boulder to the database.
    /// </summary>
    /// <param name="boulder">The boulder to be added.</param>
    /// <returns>The number of objects written to the underlying database.</returns>
    public async Task<int> AddBoulder(Boulder boulder) {
        await _context.Boulders.AddAsync(boulder);
        var res = await _context.SaveChangesAsync();
        return res;
    }
}