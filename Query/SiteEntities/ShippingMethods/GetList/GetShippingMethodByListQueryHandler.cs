using Common.Query;
using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.ShippingMethods.GetList;

public class GetShippingMethodByListQueryHandler : IQueryHandler<GetShippingMethodByListQuery,List<ShippingMethodDto>>
{
    private readonly ShopContext _context;

    public GetShippingMethodByListQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<List<ShippingMethodDto>> Handle(GetShippingMethodByListQuery request, CancellationToken cancellationToken)
    {
        return await _context.ShippingMethods.Select(s => new ShippingMethodDto()
        {
            Id = s.Id,
            CreationDate = s.CreationDate,
            Title = s.Title,
            Cost = s.Cost
        }).ToListAsync(cancellationToken);
    }
}