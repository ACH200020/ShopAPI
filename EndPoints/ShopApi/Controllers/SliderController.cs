using Application.SiteEntities.Sliders.Create;
using Application.SiteEntities.Sliders.Edit;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.SiteEntities.Slider;
using Query.SiteEntities.DTOs;

namespace ShopApi.Controllers
{
    
    public class SliderController : ApiController
    {

        private readonly ISliderFacade _sliderFacade;

        public SliderController(ISliderFacade sliderFacade)
        {
            _sliderFacade = sliderFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<SliderDto>>> GetList()
        {
            var result = await _sliderFacade.GetSliders();
            return QueryResult(result);
        }

        [HttpGet("{sliderId}")]
        public async Task<ApiResult<SliderDto?>> GetById(long id)
        {
            var result = await _sliderFacade.GetSliderById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create([FromForm] CreateSliderCommand command)
        {
            var result = await _sliderFacade.CreateSlider(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditSliderCommand command)
        {
            var result = await _sliderFacade.EditSlider(command);
            return CommandResult(result);
        }

        [HttpDelete("{sliderId}")]
        public async Task<ApiResult> Delete(long sliderId)
        {
            var result = await _sliderFacade.DeleteSlider(sliderId);
            return CommandResult(result);
        }
    }
}
