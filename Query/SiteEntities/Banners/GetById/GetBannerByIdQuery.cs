using System.Net.Sockets;
using Common.Query;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.Banners.GetById;

public record GetBannerByIdQuery(long BannerId) : IQuery<BannerDto>;