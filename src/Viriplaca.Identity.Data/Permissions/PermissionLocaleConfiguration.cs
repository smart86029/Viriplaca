using Viriplaca.Common.Data.Localization;
using Viriplaca.Identity.Domain.Permissions;

namespace Viriplaca.Identity.Data.Permissions;

internal class PermissionLocaleConfiguration : EntityLocaleConfiguration<Permission, PermissionLocale>
{
    public override void Configure(EntityTypeBuilder<PermissionLocale> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(32);

        builder
            .Property(x => x.Description)
            .HasMaxLength(128);
    }
}
