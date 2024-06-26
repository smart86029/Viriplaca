namespace Deopeia.Identity.Infrastructure;

public class IdentityContext(DbContextOptions<IdentityContext> options) : DbContext(options)
{
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.ApplyConventions();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("Identity")
            .ApplyConfigurationsFromAssembly(GetType().Assembly)
            .ApplyCommonConfigurations();
    }
}
