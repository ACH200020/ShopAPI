using Common.Query;
using Query.Sellers.DTOs;

namespace Query.Sellers.GetByUserId;

public record GetSellerByUserIdQuery(long UserId) : IQuery<SellerDto?>;