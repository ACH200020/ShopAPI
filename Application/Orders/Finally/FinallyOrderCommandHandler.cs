using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Application.Orders.Finally;

public class FinallyOrderCommandHandler : IBaseCommandHandler<FinallyOrderCommand>
{
    private readonly IOrderRepository _repository;

    public FinallyOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(FinallyOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetCurrentUserOrder(request.UserId);
        if (order == null)
        {
            return OperationResult.NotFound();
        }
        order.Finally();
        await _repository.Save();
        return OperationResult.Success();
    }
}