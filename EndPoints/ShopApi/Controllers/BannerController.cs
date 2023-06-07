using Application.SiteEntities.Banners.Create;
using Application.SiteEntities.Banners.Edit;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.SiteEntities.Banner;
using Query.SiteEntities.DTOs;

namespace ShopApi.Controllers
{

    public class BannerController : ApiController
    {
        private readonly IBannerFacade _bannerFacade;

        public BannerController(IBannerFacade bannerFacade)
        {
            _bannerFacade = bannerFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<BannerDto>>> GetList()
        {
            var result = await _bannerFacade.GetBanner();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<BannerDto?>> GetById(long id)
        {
            var result = await _bannerFacade.GetBannerById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create([FromForm] CreateBannerCommand command)
        {
            var result = await _bannerFacade.CreateBanner(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditBannerCommand command)
        {
            var result = await _bannerFacade.EditBanner(command);
            return CommandResult(result);
        }

        [HttpDelete("{bannerId}")]

        public async Task<ApiResult> Delete(long bannerId)
        {
            var result = await _bannerFacade.DeleteBanner(bannerId);
            return CommandResult(result);
        }
    }
}
