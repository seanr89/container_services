
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class LocationConfig : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> entity)
    {
        #region Properties

        entity.HasKey(a => a.Id);
        entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
        entity.Property(p => p.Active).IsRequired().HasDefaultValue(true);
        entity.Property(p => p.IsPrivate).IsRequired().HasDefaultValue(false);

        #endregion

        #region Relationships
        entity
            .HasMany(c => c.BoulderGroups)
            .WithOne(m => m.GymLocation)
            .OnDelete(DeleteBehavior.Cascade);

        entity
            .HasMany(c => c.Users)
            .WithOne(m => m.GymLocation)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion
    }
}