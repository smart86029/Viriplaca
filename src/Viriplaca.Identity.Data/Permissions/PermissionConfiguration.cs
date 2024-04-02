using Viriplaca.Identity.Domain.Permissions;

namespace Viriplaca.Identity.Data.Permissions;

internal class PermissionConfiguration : EntityConfiguration<Permission>
{
    public override void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder
            .Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(32);

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
    }
}
