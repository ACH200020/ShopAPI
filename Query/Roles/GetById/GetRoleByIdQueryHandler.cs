using Common.Query;
using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.Roles.DTOs;

namespace Query.Roles.GetById;

public class GetRoleByIdQueryHandler :IQueryHandler<GetRoleByIdQuery,RoleDto>
{
    private readonly ShopContext _context;

    public GetRoleByIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(f => f.Id == request.RoleId, cancellationToken);
        if (role == null)
        {
            return null;
        }

        return new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Permissions = role.Permissions.Select(s => s.Permission).ToList(),
            Titile = role.Title
        };
    }
}