using Application.Users.AddAddress;
using Application.Users.DeleteAddress;
using Application.Users.EditAddress;
using Application.Users.SetActiveAddress;
using Common.Application;
using MediatR;
using Query.Users.Address.GetById;
using Query.Users.Address.GetList;
using Query.Users.DTOs;

namespace Presentation.Facade.Users.Addresses;

public interface IUserAddressesFacade
{
    Task<OperationResult> AddAddress(AddUserAddressCommand command);

    Task<OperationResult> EditAddress(EditUserAddressCommand command);
    Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);

    Task<AddressDto?> GetById(long userAddressId);
    Task<List<AddressDto>> GetList(long userId);
    Task<OperationResult> SetActiveAddress(SetUserActiveAddressCommand command);
}

public class UserAddressesFacade:IUserAddressesFacade
{
    private readonly IMediator _mediator;

    public UserAddressesFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddAddress(AddUserAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditAddress(EditUserAddressCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<AddressDto?> GetById(long userAddressId)
    {
        return await _mediator.Send(new GetUserAddressesByIdQuery(userAddressId));
    }

    public async Task<List<AddressDto>> GetList(long userId)
    {
        return await _mediator.Send(new GetUserAddressesListQuery(userId));
    }

    public async Task<OperationResult> SetActiveAddress(SetUserActiveAddressCommand command)
    {
            return await _mediator.Send(command);

    }
}