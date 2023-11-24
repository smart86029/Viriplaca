namespace Viriplaca.Identity.Domain.Users;

public class UserCreated(Guid userId, string name, string displayName)
    : DomainEvent
{
    public Guid UserId { get; private init; } = userId;

    public string Name { get; private init; } = name;

    public string DisplayName { get; private init; } = displayName;
}
