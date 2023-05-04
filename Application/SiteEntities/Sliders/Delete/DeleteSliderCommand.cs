using Common.Application;
using FluentValidation;

namespace Application.SiteEntities.Sliders.Delete;

public record DeleteSliderCommand(long Id) : IBaseCommand;