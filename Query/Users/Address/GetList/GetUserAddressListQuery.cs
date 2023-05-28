using Common.Query;
using Query.Users.DTOs;

namespace Query.Users.Address.GetList;

public record GetUserAddressesListQuery(long UserId) : IQuery<List<AddressDto>>;