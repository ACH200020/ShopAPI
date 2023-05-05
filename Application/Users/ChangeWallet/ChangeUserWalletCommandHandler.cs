using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Application.Users.ChangeWallet;

public class ChangeUserWalletCommandHandler : IBaseCommandHandler<ChangeUserWalletCommand>
{
    private readonly IUserRepository _repository;

    public ChangeUserWalletCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(ChangeUserWalletCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
        {
            return OperationResult.NotFound();
        }

        var wallet = new Wallet(request.Price, request.Description, request.IsFinally, request.Type);
        user.ChargeWallet(wallet);
        await _repository.Save();
        return OperationResult.Success();
    }
}