
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class BoulderConfig : IEntityTypeConfiguration<Boulder>
{
    public void Configure(EntityTypeBuilder<Boulder> entity)
    {
        #region Properties

        entity.HasKey(a => a.Id);
        //entity.Property(p => p.Id).HasDefaultValueSql("uuid_generate_v4()");
        entity.Property(p => p.Name).IsRequired().HasMaxLength(150);
        entity.Property(p => p.Active).IsRequired().HasDefaultValue(true);

        #endregion
    }
}