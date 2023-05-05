using Common.Application;
using FluentValidation;

namespace Application.Orders.Finally;

public record FinallyOrderCommand(long UserId) : IBaseCommand;