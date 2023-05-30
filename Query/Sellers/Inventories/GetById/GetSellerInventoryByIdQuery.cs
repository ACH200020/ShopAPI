using Common.Query;
using Query.Sellers.DTOs;


namespace Query.Sellers.Inventories.GetById;

public record GetSellerInventoryByIdQuery(long InventoryId) : IQuery<InventoriesDto>;