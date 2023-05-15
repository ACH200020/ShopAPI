using Infrastructure._Utilities;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Infrastructure.Persistent.EF.RoleAgg;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(ShopContext context) : base(context)
    {
    }
}