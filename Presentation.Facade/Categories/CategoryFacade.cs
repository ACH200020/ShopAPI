using Application.Categories.AddChild;
using Application.Categories.Create;
using Application.Categories.Edit;
using Application.Categories.Remove;
using Common.Application;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Query.Categories.DTOs;
using Query.Categories.GetById;
using Query.Categories.GetByParentId;
using Query.Categories.GetList;

namespace Presentation.Facade.Categories;

internal class CategoryFacade : ICategoryFacade
{
    private readonly IMediator _mediator;
    private readonly IDistributedCache _cache;

    public CategoryFacade(IMediator mediator, IDistributedCache cache)
    {
        _mediator = mediator;
        _cache = cache;
    }

    public async Task<OperationResult<long>> AddChild(AddChildCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult<long>> Create(CreateCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Remove(long categoryId)
    {
        return await _mediator.Send(new RemoveCategoryCommand(categoryId));

    }

    public async Task<CategoryDto> GetCategoryById(long categoryId)
    {
        return await _mediator.Send(new GetCategoryByIdQuery(categoryId));
    }

    public async Task<List<ChildCategoryDto>> GetCategoriesByParentId(long parentId)
    {
        return await _mediator.Send(new GetCategoryByParentIdQuery(parentId));
    }

    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _mediator.Send(new GetCategoryListQuery());

    }
}