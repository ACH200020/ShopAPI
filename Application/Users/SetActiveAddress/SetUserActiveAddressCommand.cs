using Common.Application;
using FluentValidation;

namespace Application.Users.SetActiveAddress;

public record SetUserActiveAddressCommand(long UserId, long AddressId) : IBaseCommand;