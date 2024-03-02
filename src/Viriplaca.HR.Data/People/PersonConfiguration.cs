using Viriplaca.HR.Domain.People;

namespace Viriplaca.HR.Data.People;

internal class PersonConfiguration : EntityConfiguration<Person>
{
    public override void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(32);

        builder
            .Property(x => x.LastName)
            .HasMaxLength(32);

        builder.HasIndex(x => x.UserId);
    }
}
