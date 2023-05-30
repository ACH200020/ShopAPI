using Application.Users.AddToken;
using Application.Users.ChangePassword;
using Application.Users.Create;
using Application.Users.Edit;
using Application.Users.Register;
using Application.Users.RemoveToken;
using Common.Application;
using MediatR;
using Query.Users.DTOs;
using Query.Users.GetByFilter;
using Query.Users.GetById;
using Query.Users.GetByPhoneNumber;

namespace Presentation.Facade.Users;

public class UserFacade:IUserFacade
{
    private readonly IMediator _mediator;

    public UserFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> RegisterUser(RegisterUserCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> EditUser(EditUserCommand command)
    {
        
    }

    public async Task<OperationResult> CreateUser(CreateUserCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> AddToken(AddUserTokenCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> RemoveToken(RemoveUserTokenCommand command)
    {

    }

    public async Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }

    public async Task<UserDto?> GetUserById(long userId)
    {
        return await _mediator.Send(new GetUserByIdQuery(userId));
    }

    public Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
    {
        
    }

    public Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
    {
        
    }

    public Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
    {
        return await _mediator.Send(new GetUserByFilterQuery(filterParams));
    }
}