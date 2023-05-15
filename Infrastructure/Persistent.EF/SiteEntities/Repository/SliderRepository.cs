using Infrastructure._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;

namespace Infrastructure.Persistent.EF.SiteEntities.Repository;

public class SliderRepository : BaseRepository<Slider>,ISliderRepository
{
    public SliderRepository(ShopContext context) : base(context)
    {
    }

    public void Delete(Slider slider)
    {
        Context.Sliders.Remove(slider);
    }
}