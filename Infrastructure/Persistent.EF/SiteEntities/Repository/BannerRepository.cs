using Infrastructure._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;

namespace Infrastructure.Persistent.EF.SiteEntities.Repository;

public class BannerRepository : BaseRepository<Banner>,IBannerRepository
{
    public BannerRepository(ShopContext context) : base(context)
    {
    }

    public void Delete(Banner banner)
    {
        Context.Banners.Remove(banner);
    }
}