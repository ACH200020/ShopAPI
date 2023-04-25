using Common.Domain;
using Domain.RoleAgg.Enum;

namespace Domain.RoleAgg;

public class RolePermissions : BaseEntity
{
    public RolePermissions(Permission permissions)
    {

        Permissions = permissions;
    }
    public long RoleId { get; internal set; }
    public Permission Permissions { get;private set; }
}