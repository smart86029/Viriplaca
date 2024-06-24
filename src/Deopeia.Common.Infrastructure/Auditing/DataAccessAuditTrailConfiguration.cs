using Deopeia.Common.Domain.Auditing;
using Deopeia.Common.Infrastructure.Comparers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deopeia.Common.Infrastructure.Auditing;

public class DataAccessAuditTrailConfiguration : IEntityTypeConfiguration<DataAccessAuditTrail>
{
    public void Configure(EntityTypeBuilder<DataAccessAuditTrail> builder)
    {
        builder
            .Property(x => x.Keys)
            .HasConversion<JsonConverter<IReadOnlyDictionary<string, object>>>(
                new DictionaryComparer<string, object>()
            );

        builder
            .Property(x => x.OldValues)
            .HasConversion<JsonConverter<IReadOnlyDictionary<string, object?>>>(
                new DictionaryComparer<string, object?>()
            );

        builder
            .Property(x => x.NewValues)
            .HasConversion<JsonConverter<IReadOnlyDictionary<string, object?>>>(
                new DictionaryComparer<string, object?>()
            );

        builder
            .Property(x => x.PropertyNames)
            .HasConversion<JsonConverter<IReadOnlyCollection<string>>>(
                new EnumerableComparer<string>()
            );
    }
}
