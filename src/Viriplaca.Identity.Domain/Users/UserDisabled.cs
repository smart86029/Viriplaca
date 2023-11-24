namespace Viriplaca.Identity.Domain.Users;

public class UserDisabled(Guid userId)
    : DomainEvent
{
    public Guid UserId { get; private init; } = userId;
}
