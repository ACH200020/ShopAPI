using Common.Application;

namespace Application.SiteEntities.Banners.Delete;

public record DeleteBannerCommand(long Id) : IBaseCommand;