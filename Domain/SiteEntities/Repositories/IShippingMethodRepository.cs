using Common.Domain.Repository;

namespace Domain.SiteEntities.Repositories;

public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
{
    void Delete(ShippingMethod method);
}