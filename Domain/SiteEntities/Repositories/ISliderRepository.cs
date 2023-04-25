using Common.Domain.Repository;
using Domain.SiteEntities;

namespace Domain.SiteEntities.Repositories
{
    public interface ISliderRepository : IBaseRepository<Slider>
    {
        void Delete(Slider slider);
    }
}
