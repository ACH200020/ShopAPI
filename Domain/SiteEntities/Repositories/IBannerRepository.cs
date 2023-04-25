using Common.Domain.Repository;
using Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SiteEntities.Repositories
{
    public interface IBannerRepository : IBaseRepository<Banner>
    {
        void Delete(Banner banner);
    }
}