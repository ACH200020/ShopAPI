using Common.Application;

namespace Application.Orders.IncreaseItemCount;

public record IncreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;