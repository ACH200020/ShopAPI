using Common.Domain;
using Common.Domain.Exceptions;

namespace Domain.RoleAgg;

public class Role : AggregateRoot
{
    public string Title { get; private set; }
    public List<RolePermissions> Permissions { get; private set; }

    private Role()
    {
    }
    public Role(string title, List<RolePermissions> permissions)
    {
        Title = title;
        Permissions = permissions;
    }

    public Role(string title)
    {
        NullOrEmptyDomainDataException.CheckString(title,nameof(title));
        Title = title;
        Permissions = new List<RolePermissions>();
    }

    public void Edit(string title)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        Title = title;

    }

    public void SetPermissions(List<RolePermissions> permissions)
    {
        Permissions = permissions;
    }
}