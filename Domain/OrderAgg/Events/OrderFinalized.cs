using Common.Domain;

namespace Domain.OrderAgg.Events;

public class OrderFinalized : BaseDomainEvent
{
    public OrderFinalized(long orderId)
    {
        OrderId = orderId;
    }

    public long OrderId { get; private set; }
}