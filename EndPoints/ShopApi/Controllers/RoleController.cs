﻿using Application.Roles.Create;
using Application.Roles.Edit;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.Roles;
using Query.Roles.DTOs;

namespace ShopApi.Controllers
{
    
    public class RoleController : ApiController
    {
        private readonly IRoleFacade _roleFacade;

        public RoleController(IRoleFacade roleFacade)
        {
            _roleFacade = roleFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<RoleDto>>> GetRoles()
        {
            var result = await _roleFacade.GetRoles();
            return QueryResult(result);
        }

        [HttpGet("{roleId}")]
        public async Task<ApiResult<RoleDto?>> GetRoleById(long id)
        {
            var result = await _roleFacade.GetRoleById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> CreateRole(CreateRoleCommand command)
        {
            var result = await _roleFacade.CreateRole(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditRole(EditRoleCommand command)
        {
            var result = await _roleFacade.EditRole(command);
            return CommandResult(result);
        }
    }
}
