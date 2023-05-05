using Common.Application;
using FluentValidation;

namespace Application.Users.DeleteAddress;

public record DeleteUserAddressCommand(long UserId, long AddressId) : IBaseCommand;