using Common.Application;
using Shop.Domain.SiteEntities.Repositories;

namespace Application.SiteEntities.ShippingMethods.Delete;

public class DeleteShippingMethodCommandHandler : IBaseCommandHandler<DeleteShippingMethodCommand>
{
    private readonly IShippingMethodRepository _repository;

    public DeleteShippingMethodCommandHandler(IShippingMethodRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteShippingMethodCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetTracking(request.Id);
        if (result == null)
        {
            return OperationResult.NotFound();
        }
        _repository.Delete(result);
        await _repository.Save();
        return OperationResult.Success();
    }
}