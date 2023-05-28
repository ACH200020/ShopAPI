using Common.Query;
using Dapper;
using Infrastructure.Persistent.Dapper;
using Query.Users.DTOs;

namespace Query.Users.Address.GetById;

public class GetUserAddressByIdQueryHandler : IQueryHandler<GetUserAddressesByIdQuery,AddressDto?>
{

    private readonly DapperContext _dapperContext;

    public GetUserAddressByIdQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<AddressDto?> Handle(GetUserAddressesByIdQuery request, CancellationToken cancellationToken)
    {
        var sql = $"Select top 1 * from {_dapperContext.UserAddress} where id=@id";
        using var context = _dapperContext.CreateConnection();
        return await context.QueryFirstOrDefaultAsync<AddressDto>(sql, new { id = request.AddressId });
    }
}