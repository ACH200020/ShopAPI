using Common.Query;
using Query.Orders.DTOs;

namespace Query.Orders.GetById;

public record GetOrderByIdQuery(long OrderId) : IQuery<OrderDto?>;