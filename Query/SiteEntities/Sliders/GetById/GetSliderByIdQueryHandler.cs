using Common.Query;
using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.Sliders.GetById;

public class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery,SliderDto>
{
    private readonly ShopContext _context;

    public GetSliderByIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var slider = await _context.Sliders
            .FirstOrDefaultAsync(f => f.Id == request.SliderId, cancellationToken: cancellationToken);

        if (slider == null)
        {
            return null;
        }

        return new SliderDto()
        {
            Id = slider.Id,
            CreationDate = slider.CreationDate,
            ImageName = slider.ImageName,
            Link = slider.Link,
            Title = slider.Title
        };
    }
}