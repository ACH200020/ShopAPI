using Common.Domain;
using Common.Domain.Exceptions;
using Domain.UserAgg.Enums;

namespace Domain.UserAgg;

public class Wallet : BaseEntity
{
    public Wallet(int price, string description, bool isFinally, WalletType walletTyoe)
    {
        if (price < 500)
        {
            throw new InvalidDomainDataException();
        }
        Price = price;
        Description = description;
        IsFinally = isFinally;
        WalletTyoe = walletTyoe;
        if (isFinally)
        {
            FinallyDate = DateTime.Now;
        }
    }
    public long UserId { get; internal set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public DateTime? FinallyDate { get; private set; }
    public WalletType WalletTyoe { get; private set; }

    public void Finally(string refCode)
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
        Description += $"کد پیگیری : {refCode}";
    }

    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
    }
}