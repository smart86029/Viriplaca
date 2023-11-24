namespace Viriplaca.Identity.Domain.Roles;

public class RolePermission : Entity
{
    private RolePermission()
    {
    }

    public RolePermission(Guid roleId, Guid permissionId)
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }

    public Guid RoleId { get; private init; }

    public Guid PermissionId { get; private init; }
}
