using Application.Orders.AddItem;
using Application.Orders.Checkout;
using Application.Orders.DecreaseItemCount;
using Application.Orders.Finally;
using Application.Orders.IncreaseItemCount;
using Application.Orders.RemoveItem;
using Application.Orders.SendOrder;
using Common.Application;
using MediatR;
using Query.Orders.DTOs;
using Query.Orders.GetByFilter;
using Query.Orders.GetById;
using Query.Orders.GetCurrent;

namespace Presentation.Facade.Orders;

internal class OrderFacade : IOrderFacade
{
    private readonly IMediator _mediator;

    public OrderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddOrderItem(AddOrderItemCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> FinallyOrder(FinallyOrderCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> SendOrder(long orderId)
    {
        return await _mediator.Send(new SendOrderCommand(orderId));
    }

    public async Task<OrderDto?> GetOrderById(long orderId)
    {
        return await _mediator.Send(new GetOrderByIdQuery(orderId));
    }

    public async Task<OrderFilterResult> GetOrderByFilter(OrderFilterParams filterParams)
    {
        return await _mediator.Send(new GetOrdersByFilterQuery(filterParams));
    }

    public async Task<OrderDto?> GetCurrentOrder(long userId)
    {
        return await _mediator.Send(new GetCurrentUserOrderQuery(userId));
    }
}