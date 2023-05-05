using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;

namespace Application.Orders.SendOrder;

public class SendOrderCommandHandler : IBaseCommandHandler<SendOrderCommand>
{
    private readonly IOrderRepository _repository;

    public SendOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(SendOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetTracking(request.OrderId);
        if (order == null)
        {
            return OperationResult.NotFound();
        }
        order.ChangeStatus(OrderStatus.Shipping);
        await _repository.Save();
        return OperationResult.Success();
    }
}