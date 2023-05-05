using Common.Application;

namespace Application.Orders.SendOrder;

public record SendOrderCommand(long OrderId) : IBaseCommand;