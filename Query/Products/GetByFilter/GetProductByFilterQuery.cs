using Common.Query;
using Query.Products.DTOs;

namespace Query.Products.GetByFilter;

public class GetProductByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
{
    public GetProductByFilterQuery(ProductFilterParams filterParam) : base(filterParam)
    {
    }
}