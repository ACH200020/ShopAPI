using System.Xml.Serialization;
using Common.Domain;
using Common.Domain.Exceptions;
using Domain.Enums;
using Domain.Services;

namespace Domain.UserAgg;

public class User : AggregateRoot
{
    public User(string name, string family, string email, string password, string phoneNumber, Gender gender)
    {
        Name = name;
        Family = family;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Gender = gender;

    }

    public string Name { get; private set; }
    public string Family { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string PhoneNumber { get; private set; }
    public Gender Gender { get; private set; }
    public List<UserRole> Roles { get; private set; }
    public List<Wallet> Wallets { get; private set; }
    public List<UserAddress> Addresses { get; private set; }

    public void Edit(string name, string family, string phoneNumber, string email,
        Gender gender, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
    }

    public void AddAddress(UserAddress address)
    {
        address.UserId = Id;
        Addresses.Add(address);
    }

    public void DeleteAddress(long addressId)
    {
        var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
        if (oldAddress == null)
        {
            throw new NullOrEmptyDomainDataException("آدرس پیدا نشد");
        }

        Addresses.Remove(oldAddress);
    }

    public void ChargeWallet(Wallet wallet)
    {
        wallet.UserId = Id;
        Wallets.Add(wallet);
    }

    public void SetRoles(List<UserRole> roles)
    {
        roles.ForEach(f => f.UserId = Id);
        Roles.Clear();
        Roles.AddRange(roles);
    }

    public void Guard(string phoneNumber, string email, IUserDomainService userDomainService)
    {
        NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

        if (phoneNumber.Length != 11)
            throw new InvalidDomainDataException("شماره موبایل نامعتبر است");

        if (!string.IsNullOrWhiteSpace(email))
            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException(" ایمیل  نامعتبر است");

        if (phoneNumber != PhoneNumber)
            if (userDomainService.PhoneNumberIsExist(phoneNumber))
                throw new InvalidDomainDataException("شماره موبایل تکراری است");

        if (email != Email)
            if (userDomainService.IsEmailExist(email))
                throw new InvalidDomainDataException("ایمیل تکراری است");
    }
}