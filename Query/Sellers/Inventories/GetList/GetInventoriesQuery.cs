using Common.Query;
using Query.Sellers.DTOs;


namespace Query.Sellers.Inventories.GetList;

public record GetInventoriesQuery(long SellerId) : IQuery<List<InventoriesDto>>;