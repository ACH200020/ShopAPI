using Application.Categories.AddChild;
using Application.Categories.Create;
using Application.Categories.Edit;
using Common.Application;
using Query.Categories.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Presentation.Facade.Categories;

public interface ICategoryFacade
{
    Task<OperationResult<long>> AddChild(AddChildCategoryCommand command);
    Task<OperationResult> Edit(EditCategoryCommand  command);
    Task<OperationResult<long>> Create(CreateCategoryCommand  command);
    Task<OperationResult> Remove(long categoryId);


    Task<CategoryDto> GetCategoryById(long categoryId);
    Task<List<ChildCategoryDto>> GetCategoriesByParentId(long parentId);
    Task<List<CategoryDto>> GetCategories();
}