using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg.Repository;

namespace Application.Users.ChangePassword;

public class ChangeUserPasswordCommandHandler : IBaseCommandHandler<ChangeUserPasswordCommand>
{
    private readonly IUserRepository _repository;

    public ChangeUserPasswordCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
        {
            return OperationResult.NotFound();
        }

        var currentPassword = Sha256Hasher.Hash(request.CurrentPassword);
        if (user.Password != currentPassword)
        {
            return OperationResult.Error("کلمه عبور فعلی نامعتر است");
        }
        var newPassword = Sha256Hasher.Hash(request.Password);
        user.ChangePassword(newPassword);
        await _repository.Save();
        return OperationResult.Success();
    }
}