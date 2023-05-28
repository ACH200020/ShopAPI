using Common.Query;
using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.Sellers.DTOs;

namespace Query.Sellers.GetByUserId;

public class GetSellerByUserIdQueryHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto?>
{
    private readonly ShopContext _context;

    public GetSellerByUserIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<SellerDto?> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _context.Sellers.FirstOrDefaultAsync(f => f.UserId == request.UserId,
            cancellationToken: cancellationToken);
        if (seller == null)
        {
            return null;
        }

        return seller.Map();

    }
}