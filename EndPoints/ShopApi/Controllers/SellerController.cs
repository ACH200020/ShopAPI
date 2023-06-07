using Application.Sellers.AddInventory;
using Application.Sellers.Create;
using Application.Sellers.EditInventory;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.Sellers;
using Presentation.Facade.Sellers.Inventories;
using Query.Sellers.DTOs;
using Shop.Domain.SellerAgg;

namespace ShopApi.Controllers
{
    
    public class SellerController : ApiController
    {

        private readonly ISellerFacade _sellerFacade;
        private readonly ISellerInventoriesFacade _inventoriesFacade;

        public SellerController(ISellerFacade sellerFacade, ISellerInventoriesFacade inventoriesFacade)
        {
            _sellerFacade = sellerFacade;
            _inventoriesFacade = inventoriesFacade;
        }

        [HttpGet]
        public async Task<ApiResult<SellerFilterResult>> GetSellers(SellerFilterParams filterParams)
        {
            var result = await _sellerFacade.GetSellersByFilter(filterParams);
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<SellerDto?>> GetSellerById(long sellerId)
        {
            var result = await _sellerFacade.GetSellerById(sellerId);
            return QueryResult(result);
        }

        [HttpGet("current")]
        public async Task<ApiResult<SellerDto?>> GetSeller()
        {
            var result = await _sellerFacade.GetSellerByUserId(User.GetUserId());
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> CreateSeller(CreateSellerCommand command)
        {
            var result = await _sellerFacade.CreateSeller(command);
            return CommandResult(result);
        }

        [HttpPost("Inventory")]
        public async Task<ApiResult> AddInventory(AddSellerInventoryCommand command)
        {
            var result = await _inventoriesFacade.AddInventory(command);
            return CommandResult(result);
        }

        [HttpPut("Inventory")]
        public async Task<ApiResult> EditInventory(EditSellerInventoryCommand command)
        {
            var result = await _inventoriesFacade.EditInventory(command);
            return CommandResult(result);
        }

        [HttpGet("Inventory")]
        public async Task<ApiResult<List<InventoriesDto>>> GetInventories()
        {
            var seller = await _sellerFacade.GetSellerByUserId(User.GetUserId());
            if (seller == null)
                return QueryResult(new List<InventoriesDto>());

            var result = await _inventoriesFacade.GetList(seller.Id);
            return QueryResult(result);
        }

        [HttpGet("Inventory/{inventoryId}")]
        public async Task<ApiResult<InventoriesDto>> GetInventoryById(long inventoryId)
        {
            var result = await _inventoriesFacade.GetById(inventoryId);
            if (result == null)
                return QueryResult(new InventoriesDto());
            return QueryResult(result);
        }
    }
}
