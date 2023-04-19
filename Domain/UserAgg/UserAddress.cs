using Common.Domain;
using Common.Domain.Exceptions;

namespace Domain.UserAgg;

public class UserAddress : BaseEntity
{
    public UserAddress(string shire, string postalCode, string postalAddress, string city, string phoneNumber, string name, string family, string nationalCode, bool activeAddress)
    {

        Guard(shire, postalCode, postalAddress, city, phoneNumber,
            name, family, nationalCode);
        Shire = shire;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        City = city;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        ActiveAddress = activeAddress;
    }
    public long UserId { get; internal set; }
    public string Shire { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string City { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
    public bool ActiveAddress { get; private set; }

    public void Edit(string shire, string postalCode, string postalAddress, string city, string phoneNumber,
        string name, string family, string nationalCode)
    {
        Guard(shire, postalCode, postalAddress, city, phoneNumber,
             name, family, nationalCode);
        Shire = shire;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        City = city;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }

    public void SetActive()
    {
        ActiveAddress = true;
    }

    public void SetDeActive()
    {
        ActiveAddress = false;
    }

    public void Guard(string shire, string postalCode, string postalAddress, string city, string phoneNumber,
        string name, string family, string nationalCode)
    {
        NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
        NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmptyDomainDataException.CheckString(city, nameof(city));
        NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmptyDomainDataException.CheckString(name, nameof(name));
        NullOrEmptyDomainDataException.CheckString(family, nameof(family));

        if (IranianNationalIdChecker.IsValid(nationalCode) == false)
            throw new InvalidDomainDataException("کدملی نامعتبر است");
        
    }
}