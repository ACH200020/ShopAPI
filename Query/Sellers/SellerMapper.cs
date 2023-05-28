using Query.Sellers.DTOs;
using Shop.Domain.SellerAgg;

namespace Query.Sellers;

public static class SellerMapper
{
    public static SellerDto Map(this Seller seller)
    {
        if (seller == null)
        {
            return null;
        }

        return new SellerDto()
        {
            Id = seller.Id,
            CreationDate = seller.CreationDate,
            Status = seller.Status,
            NationalCode = seller.NationalCode,
            ShopName = seller.ShopName,
            UserId = seller.UserId
        };
    }
}