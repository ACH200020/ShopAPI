namespace Domain.Services;

public interface IUserDomainService
{
    bool IsEmailExist(string email);
    bool PhoneNumberIsExist(string phoneNumber);
}