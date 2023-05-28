using System.Security.Permissions;
using Common.Query;
using Shop.Domain.RoleAgg.Enums;

namespace Query.Roles.DTOs;

public class RoleDto : BaseDto
{
    public string Titile { get; set; }
    public List<Permission> Permissions { get; set; }
    
}