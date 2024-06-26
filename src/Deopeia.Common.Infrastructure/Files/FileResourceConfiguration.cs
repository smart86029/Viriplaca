using Deopeia.Common.Domain.Files;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deopeia.Common.Infrastructure.Files;

public class FileResourceConfiguration : IEntityTypeConfiguration<FileResource>
{
    public void Configure(EntityTypeBuilder<FileResource> builder)
    {
        builder.HasDiscriminator(x => x.Type).HasValue<Image>(FileResourceType.Image);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(128);

        builder.Property(x => x.Extension).IsRequired().HasMaxLength(16);

        builder.Ignore(x => x.Content);
        builder.Ignore(x => x.PresignedUri);

        builder.ToTable(nameof(FileResource), "Common");

        builder.HasIndex(x => x.Type);
    }
}
