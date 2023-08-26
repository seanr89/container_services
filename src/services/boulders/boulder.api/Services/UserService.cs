
public class UserService
{
    private readonly BoulderContext _dbContext;

    public UserService(BoulderContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetAll() => await _dbContext.Users.ToListAsync();

    public async Task<User> GetById(int id) => await _dbContext.Users.FindAsync(id);

}