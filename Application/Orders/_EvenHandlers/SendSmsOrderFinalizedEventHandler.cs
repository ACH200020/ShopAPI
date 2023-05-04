using MediatR;
using Shop.Domain.OrderAgg.Events;

namespace Application.Orders._EvenHandlers;

public class SendSmsOrderFinalizedEventHandler : INotificationHandler<OrderFinalized>
{
    public async Task Handle(OrderFinalized notification, CancellationToken cancellationToken)
    {
        await Task.Delay(10000, cancellationToken);
        Console.WriteLine("-----------------------------------------------");
    }
}