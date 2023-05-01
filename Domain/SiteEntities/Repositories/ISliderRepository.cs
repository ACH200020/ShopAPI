
using Common.Domian.Repository;

namespace Shop.Domain.SiteEntities.Repositories
{
    public interface ISliderRepository : IBaseRepository<Slider>
    {
        void Delete(Slider slider);
    }
}
