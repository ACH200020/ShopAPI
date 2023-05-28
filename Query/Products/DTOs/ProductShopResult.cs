using Common.Query.Filter;
using Query.Categories.DTOs;

namespace Query.Products.DTOs;

public class ProductShopResult : BaseFilter<ProductShopDto,ProductShopFilterParam>
{
    public CategoryDto? CategoryDto { get; set; }
}