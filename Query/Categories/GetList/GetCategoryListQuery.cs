using Common.Query;
using Query.Categories.DTOs;

namespace Query.Categories.GetList;

public record GetCategoryListQuery : IQuery<List<CategoryDto>>;