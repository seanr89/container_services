using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class LocationService
{
    private readonly BoulderContext _dbContext;

    public LocationService(BoulderContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Location>> GetAllLocations() => await _dbContext.Locations.ToListAsync();

    public async Task<Location> GetLocationById(int id) => await _dbContext.Locations.FindAsync(id);

    public async Task CreateLocation(Location location)
    {
        _dbContext.Locations.Add(location);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateLocation(Location location)
    {
        _dbContext.Entry(location).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteLocation(Location location)
    {
        _dbContext.Locations.Remove(location);
        await _dbContext.SaveChangesAsync();
    }
}