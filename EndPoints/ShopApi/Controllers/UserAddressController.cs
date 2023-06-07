using Application.Users.AddAddress;
using Application.Users.DeleteAddress;
using Application.Users.EditAddress;
using Application.Users.SetActiveAddress;
using AutoMapper;
using Common.AspNetCore;
using Common.Domian.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.Users.Addresses;
using Query.Users.DTOs;
using Shop.Api.ViewModels.Users;


namespace Shop.Api.Controllers;

[Authorize]
public class UserAddressController : ApiController
{
    private readonly IUserAddressesFacade _userAddress;
    private readonly IMapper _mapper;
    public UserAddressController(IUserAddressesFacade userAddress, IMapper mapper)
    {
        _userAddress = userAddress;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ApiResult<List<AddressDto>>> GetList()
    {
        var result = await _userAddress.GetList(User.GetUserId());
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<AddressDto?>> GetById(long id)
    {
        var result = await _userAddress.GetById(id);
        return QueryResult(result);
    }
    [HttpPost]
    public async Task<ApiResult> AddAddress(AddUserAddressViewModel viewModel)
    {
        var command = new AddUserAddressCommand(User.GetUserId(), viewModel.Shire, viewModel.City, viewModel.PostalCode,
            viewModel.PostalAddress, new PhoneNumber(viewModel.PhoneNumber), viewModel.Name,
            viewModel.Family, viewModel.NationalCode);

        var result = await _userAddress.AddAddress(command);
        return CommandResult(result);
    }

    [HttpDelete("{addressId}")]
    public async Task<ApiResult> Delete(long addressId)
    {
        var result = await _userAddress.DeleteAddress(new DeleteUserAddressCommand(User.GetUserId(), addressId));
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> Edit(EditUserAddressViewModel viewModel)
    {
        var command = new EditUserAddressCommand(viewModel.Id,User.GetUserId(),viewModel.Shire,viewModel.City,viewModel.PostalCode,
            viewModel.PostalAddress, new PhoneNumber(viewModel.PhoneNumber), viewModel.Name,viewModel.Family,viewModel.NationalCode);

        command.UserId = User.GetUserId();
        var result = await _userAddress.EditAddress(command);
        return CommandResult(result);
    }
    [HttpPut("SetActiveAddress/{addressId}")]
    public async Task<ApiResult> SetAddressActive(long addressId)
    {
        var command = new SetUserActiveAddressCommand(User.GetUserId(), addressId);

        var result = await _userAddress.SetActiveAddress(command);
        return CommandResult(result);
    }
}