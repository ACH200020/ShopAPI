using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Application.Users.SetActiveAddress;

public class SetUserActiveAddressCommandHandler : IBaseCommandHandler<SetUserActiveAddressCommand>
{
    private readonly IUserRepository _repository;

    public SetUserActiveAddressCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(SetUserActiveAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
        {
            return OperationResult.NotFound();
        }

        user.SetActiveAddress(request.AddressId);
        await _repository.Save();
        return OperationResult.Success();
    }
}