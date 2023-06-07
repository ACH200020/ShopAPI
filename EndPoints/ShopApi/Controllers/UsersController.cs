﻿using Application.Users.ChangePassword;
using Application.Users.Create;
using Application.Users.Edit;
using AutoMapper;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.Users;
using Query.Users.DTOs;

using Shop.Api.ViewModels.Users;

using Shop.Domain.RoleAgg.Enums;


namespace Shop.Api.Controllers;


[Authorize]
public class UsersController : ApiController
{
    private readonly IUserFacade _userFacade;
    private readonly IMapper _mapper;
    public UsersController(IUserFacade userFacade, IMapper mapper)
    {
        _userFacade = userFacade;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery] UserFilterParams filterParams)
    {
        var result = await _userFacade.GetUserByFilter(filterParams);
        return QueryResult(result);
    }
    [HttpGet("Current")]
    public async Task<ApiResult<UserDto>> GetCurrentUser()
    {
        var result = await _userFacade.GetUserById(User.GetUserId());
        return QueryResult(result);
    }

    [HttpGet("{userId}")]
    public async Task<ApiResult<UserDto?>> GetById(long userId)
    {
        var result = await _userFacade.GetUserById(userId);
        return QueryResult(result);
    }
    [HttpPost]
    public async Task<ApiResult> Create(CreateUserCommand command)
    {
        var result = await _userFacade.CreateUser(command);
        return CommandResult(result);
    }

    [HttpPut("ChangePassword")]
    public async Task<ApiResult> ChangePassword(ChangePasswordViewModel command)
    {
        var changePasswordModel = _mapper.Map<ChangeUserPasswordCommand>(command);
        changePasswordModel.UserId = User.GetUserId();
        var result = await _userFacade.ChangePassword(changePasswordModel);
        return CommandResult(result);
    }

    [HttpPut("Current")]
    public async Task<ApiResult> EditUser([FromForm] EditUserViewModel command)
    {
        var commandModel = new EditUserCommand(User.GetUserId(),command.Name,command.Family,command.PhoneNumber,
        command.Email,command.Gender,command.Avatar);

        var result = await _userFacade.EditUser(commandModel);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> Edit([FromForm] EditUserCommand command)
    {
        var result = await _userFacade.EditUser(command);
        return CommandResult(result);
    }
}