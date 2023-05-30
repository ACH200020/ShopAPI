using Application.SiteEntities.Sliders.Create;
using Application.SiteEntities.Sliders.Edit;
using Common.Application;
using Query.SiteEntities.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Presentation.Facade.SiteEntities.Slider;

public interface ISliderFacade
{
    Task<OperationResult> CreateSlider(CreateSliderCommand command);
    Task<OperationResult> EditSlider(EditSliderCommand command);
    Task<OperationResult> DeleteSlider(long sliderId);

    Task<SliderDto?> GetSliderById(long id);
    Task<List<SliderDto>> GetSliders();
}