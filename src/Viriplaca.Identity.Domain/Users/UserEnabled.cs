namespace Viriplaca.Identity.Domain.Users;

public class UserEnabled(Guid userId)
    : DomainEvent
{
    public Guid UserId { get; private init; } = userId;
}
