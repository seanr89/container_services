
public class DatabaseConnectionFactory
{
    private readonly string _connectionString;
    public DatabaseConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
}