using Common.Query;
using Query.Users.DTOs;

namespace Query.Users.Address.GetById;

public record GetUserAddressesByIdQuery(long AddressId) : IQuery<AddressDto?>;