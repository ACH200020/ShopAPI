using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Application.Sellers;

public class SellerDomainService : ISellerDomainService
{
    private readonly ISellerRepository _repository;

    public SellerDomainService(ISellerRepository repository)
    {
        _repository = repository;
    }

    public bool IsValidSellerInformation(Seller seller)
    {
        var sellerIsExist = _repository.Exists(f => f.NationalCode == seller.NationalCode || f.UserId == seller.UserId);
        return !sellerIsExist;
    }

    public bool NationalCodeExistInDataBase(string nationalCode)
    {
        return _repository.Exists(r => r.NationalCode == nationalCode);
    }
}