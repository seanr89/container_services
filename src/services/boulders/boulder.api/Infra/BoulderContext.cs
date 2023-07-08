
using Microsoft.EntityFrameworkCore;

public class BoulderContext : DbContext
{
    public DbSet<Boulder> Boulders { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<GradeType> GradeTypes { get; set; }
    public BoulderContext()
    {
    }

    public BoulderContext(DbContextOptions<BoulderContext> options) : base(options)
    {
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BoulderConfig());
        modelBuilder.ApplyConfiguration(new LocationConfig());
    }

    /// <summary>
    /// Supporting default and global controls for Audit events (dates and edits)
    /// </summary>
    /// <returns></returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "Unknown";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = "Unknown";
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}