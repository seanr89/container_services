
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class BoulderConfig : IEntityTypeConfiguration<Boulder>
{
    public void Configure(EntityTypeBuilder<Boulder> entity)
    {
        #region Properties

        entity.HasKey(a => a.Id);
        entity.Property(p => p.Name).IsRequired().HasMaxLength(150);
        entity.Property(p => p.Active).IsRequired().HasDefaultValue(true);

        #endregion

        #region Relationships
        entity
            .HasOne(c => c.BoulderGroup)
            .WithMany(m => m.Boulders)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion
    }
}