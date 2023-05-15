using Infrastructure._Utilities;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Infrastructure.Persistent.EF.UserAgg;

public class UserRepository : BaseRepository<User>,IUserRepository
{
    public UserRepository(ShopContext context) : base(context)
    {
    }
}