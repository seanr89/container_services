
public class UserService
{
    private readonly BoulderContext _dbContext;

    public UserService(BoulderContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetAll() => await _dbContext.Users.ToListAsync();

    public async Task<IEnumerable<User>> GetByLocation(Location location) =>
        await _dbContext.Users.Where(u => u.GymLocation == location).ToListAsync();

    public async Task<User?> GetById(int id) => await _dbContext.Users.FindAsync(id);

    public async Task<User> Create(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

}