using Common.Query;
using Dapper;
using Infrastructure.Persistent.Dapper;
using Query.Sellers.DTOs;


namespace Query.Sellers.Inventories.GetByProductId;

public record GetInventoriesByProductIdQuery(long ProductId) : IQuery<List<InventoriesDto>>;


public class GetInventoriesByProductIdQueryHandler : IQueryHandler<GetInventoriesByProductIdQuery, List<InventoriesDto>>
{
    private readonly DapperContext _context;

    public GetInventoriesByProductIdQueryHandler(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<InventoriesDto>> Handle(GetInventoriesByProductIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = _context.CreateConnection();
        var sql = @$"SELECT i.Id, i.SellerId , i.ProductId ,i.Count , i.Price,i.CreationDate , i.DiscountPercentage , s.ShopName ,
                        p.Title as ProductTitle,p.ImageName as ProductImage
            FROM {_context.Inventories} i inner join {_context.Sellers} s on i.SellerId=s.Id  
            inner join {_context.Products} p on i.ProductId=p.Id WHERE ProductId=@productId";
        var result = await connection.QueryAsync<InventoriesDto>(sql, new { productId = request.ProductId });
        return result.ToList();
    }
}