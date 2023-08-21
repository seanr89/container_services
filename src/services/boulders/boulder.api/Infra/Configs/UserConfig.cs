
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        #region Properties

        entity.HasKey(a => a.Id);
        entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
        entity.Property(p => p.IsPrivate).IsRequired().HasDefaultValue(false);

        #endregion

        #region Relationships
        // entity
        //     .HasMany(c => c.BoulderGroups)
        //     .WithOne(m => m.GymLocation)
        //     .OnDelete(DeleteBehavior.Cascade);
        #endregion
    }
}