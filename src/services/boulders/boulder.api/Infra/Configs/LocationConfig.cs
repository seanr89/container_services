
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class LocationConfig : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> entity)
    {
        #region Properties

        entity.HasKey(a => a.Id);
        entity.Property(p => p.Id).HasDefaultValueSql("NEWID()");
        entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
        entity.Property(p => p.Active).IsRequired().HasDefaultValue(true);

        #endregion
    }
}