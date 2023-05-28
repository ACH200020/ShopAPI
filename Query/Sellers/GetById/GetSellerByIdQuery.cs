using Common.Query;
using Query.Sellers.DTOs;

namespace Query.Sellers.GetById;

public class GetSellerByIdQuery : IQuery<SellerDto>
{
    public GetSellerByIdQuery(long id)
    {
        Id = id;
    }
    public long Id { get; private set; }
}