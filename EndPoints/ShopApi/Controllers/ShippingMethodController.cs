using Application.SiteEntities.ShippingMethods.Create;
using Application.SiteEntities.ShippingMethods.Edit;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.SiteEntities.ShippingMethod;
using Query.SiteEntities.DTOs;

namespace ShopApi.Controllers
{
    
    public class ShippingMethodController : ApiController
    {

        private readonly IShippingMethodFacade _shippingMethodFacade;

        public ShippingMethodController(IShippingMethodFacade shippingMethodFacade)
        {
            _shippingMethodFacade = shippingMethodFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<ShippingMethodDto>>> GetList()
        {
            var result = await _shippingMethodFacade.GetList();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<ShippingMethodDto?>> GetById(long id)
        {
            var result = await _shippingMethodFacade.GetShippingMethodById(id);
            return QueryResult(result);
        }


        [HttpPost]
        public async Task<ApiResult> Create(CreateShippingMethodCommand command)
        {
            var result = await _shippingMethodFacade.Create(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> Edit(EditShippingMethodCommand command)
        {
            var result = await _shippingMethodFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(long id)
        {
            var result = await _shippingMethodFacade.Delete(id);
            return CommandResult(result);
        }
    }
}
