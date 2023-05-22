using Common.Query;
using Query.Orders.DTOs;

namespace Query.Orders.GetByFilter;

public class GetOrdersByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
{
    public GetOrdersByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
    {
    }


}