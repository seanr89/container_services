
public class PostgresSettings
{
    public required string ConnectionString { get; set; }
    public bool Migrate { get; set; } = false;
    public bool SeedData { get; set; } = false;
}