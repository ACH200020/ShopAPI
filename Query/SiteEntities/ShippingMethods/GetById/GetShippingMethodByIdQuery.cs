using Common.Query;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.ShippingMethods.GetById;

public record GetShippingMethodByIdQuery(long Id) : IQuery<ShippingMethodDto?>;