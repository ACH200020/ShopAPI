using Common.Application;
using Shop.Domain.UserAgg;

namespace Application.Users.ChangeWallet;

public class ChangeUserWalletCommand : IBaseCommand
{
    public ChangeUserWalletCommand(long userId, int price, string description, bool isFinally, WalletType type)
    {
        UserId = userId;
        Price = price;
        Description = description;
        IsFinally = isFinally;
        Type = type;
    }
    public long UserId { get; internal set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public WalletType Type { get; private set; }
}