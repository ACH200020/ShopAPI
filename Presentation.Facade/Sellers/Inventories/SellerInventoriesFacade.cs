using Application.Sellers.AddInventory;
using Application.Sellers.EditInventory;
using Common.Application;
using MediatR;
using Query.Sellers.DTOs;
using Query.Sellers.Inventories.GetById;
using Query.Sellers.Inventories.GetByProductId;
using Query.Sellers.Inventories.GetList;

namespace Presentation.Facade.Sellers.Inventories;

public class SellerInventoriesFacade : ISellerInventoriesFacade
{
    private readonly IMediator _mediator;

    public SellerInventoriesFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<InventoriesDto?> GetById(long inventoriesId)
    {
        return await _mediator.Send(new GetSellerInventoryByIdQuery(inventoriesId));
    }

    public async Task<List<InventoriesDto>> GetList(long sellerId)
    {
        return await _mediator.Send(new GetInventoriesQuery(sellerId));
    }

    public async Task<List<InventoriesDto>> GetByProductId(long productId)
    {
        return await _mediator.Send(new GetInventoriesByProductIdQuery(productId));
    }
}