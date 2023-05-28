using Common.Query;
using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.Sliders.GetList;

public class GetSliderByListQueryHandler : IQueryHandler<GetSliderByListQuery, List<SliderDto>>
{
    private readonly ShopContext _context;

    public GetSliderByListQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<List<SliderDto>> Handle(GetSliderByListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Sliders.OrderByDescending(d => d.Id)
            .Select(slider => new SliderDto()
            {
                Id = slider.Id,
                CreationDate = slider.CreationDate,
                ImageName = slider.ImageName,
                Link = slider.Link,
                Title = slider.Title
            }).ToListAsync(cancellationToken);
    }
}