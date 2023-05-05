using Common.Application;
using FluentValidation;

namespace Application.Users.RemoveToken;

public record RemoveUserTokenCommand(long UserId, long TokenId) : IBaseCommand<string>;