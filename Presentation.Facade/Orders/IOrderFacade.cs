using Application.Orders.AddItem;
using Application.Orders.Checkout;
using Application.Orders.DecreaseItemCount;
using Application.Orders.Finally;
using Application.Orders.IncreaseItemCount;
using Application.Orders.RemoveItem;
using Common.Application;
using Query.Orders.DTOs;

namespace Presentation.Facade.Orders;

public interface IOrderFacade
{
    Task<OperationResult> AddOrderItem(AddOrderItemCommand  command);
    Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command);
    Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command);
    Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command);
    Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command);
    Task<OperationResult> FinallyOrder(FinallyOrderCommand command);
    Task<OperationResult> SendOrder(long orderId);

    Task<OrderDto?> GetOrderById(long orderId);
    Task<OrderFilterResult> GetOrderByFilter(OrderFilterParams filterParams);
    Task<OrderDto?> GetCurrentOrder(long userId);

}