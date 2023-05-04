using System.Globalization;
using Common.Application;
using Shop.Domain.RoleAgg.Enums;

namespace Application.Roles.Create;

public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;