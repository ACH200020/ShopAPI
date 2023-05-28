using Common.Query;

namespace Query.SiteEntities.DTOs;

public class ShippingMethodDto : BaseDto
{
    public string Title { get; set; }
    public int Cost { get; set; }

}