using Common.Application;
using Shop.Domain.SellerAgg;

namespace Application.Sellers.Edit;

public record EditSellerCommand(long Id, string ShopName, string NationalCode, SellerStatus Status) : IBaseCommand;