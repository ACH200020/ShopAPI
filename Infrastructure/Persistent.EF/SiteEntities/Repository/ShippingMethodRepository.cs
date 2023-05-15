using Infrastructure._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;

namespace Infrastructure.Persistent.EF.SiteEntities.Repository;

public class ShippingMethodRepository : BaseRepository<ShippingMethod>,IShippingMethodRepository
{
    public ShippingMethodRepository(ShopContext context) : base(context)
    {
    }

    public void Delete(ShippingMethod method)
    {
        Context.ShippingMethods.Remove(method);
    }
}