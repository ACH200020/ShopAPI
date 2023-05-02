using Shop.Domain.ProductAgg.Repository;

namespace Application.Products;

public class ProductDomainService
{
    private readonly IProductRepository _repository;

    public ProductDomainService(IProductRepository repository)
    {
        _repository = repository;
    }

    public bool SlugIsExist(string slug)
    {
        return _repository.Exists(s => s.Slug == slug);
    }
}