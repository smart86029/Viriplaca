namespace Viriplaca.Identity.Domain.Users;

public class UserRole : Entity
{
    private UserRole()
    {
    }

    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    public Guid UserId { get; private init; }

    public Guid RoleId { get; private init; }
}
