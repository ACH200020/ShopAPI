using Common.Query;
using Dapper;
using Infrastructure.Persistent.Dapper;
using Query.Sellers.DTOs;


namespace Query.Sellers.Inventories.GetList;

public class GetInventoriesQueryHandler : IQueryHandler<GetInventoriesQuery, List<InventoriesDto>>
{
    private readonly DapperContext _context;

    public GetInventoriesQueryHandler(DapperContext context)
    {
        _context = context;
    }
    public async Task<List<InventoriesDto>> Handle(GetInventoriesQuery request, CancellationToken cancellationToken)
    {
        using var connection = _context.CreateConnection();

        var sql = @$"SELECT i.Id, i.SellerId , i.ProductId ,i.Count , i.Price,i.CreationDate , i.DiscountPercentage , s.ShopName ,
                        p.Title as ProductTitle,p.ImageName as ProductImage
            FROM {_context.Inventories} i inner join {_context.Sellers} s on i.SellerId=s.Id  
            inner join {_context.Products} p on i.ProductId=p.Id WHERE i.SellerId=@sellerId";

        var inventories = await connection.QueryAsync<InventoriesDto>(sql, new { sellerId = request.SellerId });
        return inventories.ToList();
    }
}