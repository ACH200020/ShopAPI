﻿using Application.Users.AddToken;
using Application.Users.Register;
using Application.Users.RemoveToken;
using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Common.Domian.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.Users;
using Query.Users.DTOs;
using ShopApi.Infrastructure.JwtUtil;
using ShopApi.ViewModels.Auth;
using UAParser;

namespace ShopApi.Controllers
{
    
    public class AuthController : ApiController
    {
        private readonly IUserFacade _userFacade;
        private readonly IConfiguration _configuration;

        public AuthController(IUserFacade userFacade, IConfiguration configuration)
        {
            _userFacade = userFacade;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<ApiResult<LoginResultDto?>> Login(LoginViewModel viewModel)
        {
            var user = await _userFacade.GetUserByPhoneNumber(viewModel.PhoneNumber);
            if (user == null)
            {
                var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد");
                return CommandResult(result);
            }

            if (Sha256Hasher.IsCompare(user.Password, viewModel.Password) == false)
            {
                var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد");
                return CommandResult(result);
            }

            if (user.IsActive== false)
            {
                var result = OperationResult<LoginResultDto>.Error("حساب کاربری شما غیرفعال است");
                return CommandResult(result);
            }

            var loginResult = await AddTokenAndGenerateJwt(user);
            return CommandResult(loginResult);
        }

        [HttpPost("register")]
        public async Task<ApiResult> Register(RegisterViewModel register)
        {
            var command = new RegisterUserCommand(new PhoneNumber(register.PhoneNumber), register.Password);
            var result = await _userFacade.RegisterUser(command);
            return CommandResult(result);
        }
        [HttpPost("RefreshToken")]
        public async Task<ApiResult<LoginResultDto?>> RefreshToken(string refreshToken)
        {
            var result = await _userFacade.GetUserTokenByRefreshToken(refreshToken);

            if (result == null)
                return CommandResult(OperationResult<LoginResultDto?>.NotFound());

            if (result.TokenExpireDate > DateTime.Now)
            {
                return CommandResult(OperationResult<LoginResultDto>.Error("توکن هنوز منقضی نشده است"));
            }

            if (result.RefreshTokenExpireDate < DateTime.Now)
            {
                return CommandResult(OperationResult<LoginResultDto>.Error("زمان رفرش توکن به پایان رسیده است"));
            }
            var user = await _userFacade.GetUserById(result.UserId);
            await _userFacade.RemoveToken(new RemoveUserTokenCommand(result.UserId, result.Id));
            var loginResult = await AddTokenAndGenerateJwt(user);
            return CommandResult(loginResult);
        }


        private async Task<OperationResult<LoginResultDto?>> AddTokenAndGenerateJwt(UserDto user)
        {
            var uaParser = Parser.GetDefault();
            var header = HttpContext.Request.Headers["user-agent"].ToString();
            var device = "windows";
            if (header != null)
            {
                var info = uaParser.Parse(header);
                device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";
            }

            var token = JwtTokenBuilder.BuildToken(user, _configuration);
            var refreshToken = Guid.NewGuid().ToString();

            var hashJwt = Sha256Hasher.Hash(token);
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);

            var tokenResult = await _userFacade.AddToken(new AddUserTokenCommand(user.Id, hashJwt, hashRefreshToken,
                DateTime.Now.AddDays(7), DateTime.Now.AddDays(8), device));
            if (tokenResult.Status != OperationResultStatus.Success)
            {
                return OperationResult<LoginResultDto?>.Error();

            }

            return OperationResult<LoginResultDto?>.Success(new LoginResultDto()
            {
                Token = token,
                RefreshToken = refreshToken
            });
        }
    }
}
