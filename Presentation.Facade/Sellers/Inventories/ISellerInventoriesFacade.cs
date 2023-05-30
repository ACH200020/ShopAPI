using Application.Sellers.AddInventory;
using Application.Sellers.EditInventory;
using Common.Application;
using Query.Sellers.DTOs;

namespace Presentation.Facade.Sellers.Inventories;

public interface ISellerInventoriesFacade
{
    Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
    Task<OperationResult> EditInventory(EditSellerInventoryCommand command);

    Task<InventoriesDto?> GetById(long inventoriesId);
    Task<List<InventoriesDto>> GetList(long sellerId);
    Task<List<InventoriesDto>> GetByProductId(long productId);
}