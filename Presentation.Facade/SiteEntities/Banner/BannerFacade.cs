using Application.SiteEntities.Banners.Create;
using Application.SiteEntities.Banners.Delete;
using Application.SiteEntities.Banners.Edit;
using Common.Application;
using MediatR;
using Query.SiteEntities.Banners.GetById;
using Query.SiteEntities.Banners.GetList;
using Query.SiteEntities.DTOs;

namespace Presentation.Facade.SiteEntities.Banner;

public class BannerFacade : IBannerFacade
{
    private readonly IMediator _mediator;

    public BannerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> CreateBanner(CreateBannerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditBanner(EditBannerCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> DeleteBanner(long bannerId)
    {
        return await _mediator.Send(new DeleteBannerCommand(bannerId));

    }

    public async Task<BannerDto?> GetBannerById(long id)
    {
        return await _mediator.Send(new GetBannerByIdQuery(id));
    }

    public async Task<List<BannerDto>> GetBanner()
    {
        return await _mediator.Send(new GetBannerListQuery());
    }
}