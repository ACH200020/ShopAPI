using Application.Categories.AddChild;
using Application.Categories.Create;
using Application.Categories.Edit;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.Categories;
using Query.Categories.DTOs;
using System.Net;

namespace ShopApi.Controllers
{
    
    public class CategoryController : ApiController
    {
        private readonly ICategoryFacade _category;

        public CategoryController(ICategoryFacade category)
        {
            _category = category;
        }

        [HttpGet]
        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        {
            var result = await _category.GetCategories();
            return QueryResult(result);
        }


        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto>> GetCategoryById(long id)
        {
            var result = await _category.GetCategoryById(id);
            return QueryResult(result);
        }


        [HttpGet("getChild/{parentId}")]
        public async Task<ApiResult<List<ChildCategoryDto>>> GatCategoriesByParentId(long parentId)
        {
            var result = await _category.GetCategoriesByParentId(parentId);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult<long>> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _category.Create(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url);
        }

        [HttpPost("AddChild")]
        public async Task<ApiResult<long>> CreateCategory(AddChildCategoryCommand command)
        {
            var result = await _category.AddChild(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url);
        }

        [HttpPut]
        public async Task<ApiResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _category.Edit(command);
            return CommandResult(result);
        }
        [HttpDelete("{categoryId}")]
        public async Task<ApiResult> RemoveCategory(long categoryId)
        {
            var result = await _category.Remove(categoryId);
            return CommandResult(result);
        }
    }
}
