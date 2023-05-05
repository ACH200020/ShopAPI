using Common.Application;

namespace Application.Orders.DecreaseItemCount;

public record DecreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;