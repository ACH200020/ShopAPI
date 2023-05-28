using Common.Query;
using Query.Products.DTOs;

namespace Query.Products.GetBySlug;

public class GetProductBySlugQuery : IQuery<ProductDto?>
{
    public GetProductBySlugQuery(string slug)
    {
        Slug = slug;
    }
    public string Slug { get; private set; }
}