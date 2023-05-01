
using Common.Domian.Repository;

namespace Shop.Domain.SiteEntities.Repositories;

public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
{
    void Delete(ShippingMethod method);
}