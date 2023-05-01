
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domian.Repository;

namespace Shop.Domain.SiteEntities.Repositories
{
    public interface IBannerRepository : IBaseRepository<Banner>
    {
        void Delete(Banner banner);
    }
}