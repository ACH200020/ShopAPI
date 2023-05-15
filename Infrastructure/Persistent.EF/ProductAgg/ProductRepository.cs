using Infrastructure._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;

namespace Infrastructure.Persistent.EF.ProductAgg;

public class ProductRepository : BaseRepository<Product>,IProductRepository
{
    public ProductRepository(ShopContext context) : base(context)
    {
    }
}