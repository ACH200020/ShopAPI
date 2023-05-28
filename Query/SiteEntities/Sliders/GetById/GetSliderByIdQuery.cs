using Common.Query;
using FluentValidation;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.Sliders.GetById;

public record GetSliderByIdQuery(long SliderId) : IQuery<SliderDto>;