using Common.Query;
using Query.Roles.DTOs;

namespace Query.Roles.GetById;

public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto?>;