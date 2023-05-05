using Common.Application;
using FluentValidation;
using Shop.Domain.OrderAgg.Repository;

namespace Application.Orders.RemoveItem;

public record RemoveOrderItemCommand(long UserId, long ItemId) : IBaseCommand;


public class RemoveOrderItemCommandHandler : IBaseCommandHandler<RemoveOrderItemCommand>
{
    private readonly IOrderRepository _repository;

    public RemoveOrderItemCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetCurrentUserOrder(request.UserId);
        if (order == null)
        {
            return OperationResult.NotFound();
        }
        order.RemoveItem(request.ItemId);
        await _repository.Save();
        return OperationResult.Success();
    }
}

