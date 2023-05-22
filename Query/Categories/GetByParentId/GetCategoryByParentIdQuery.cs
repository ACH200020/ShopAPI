using Common.Query;
using Query.Categories.DTOs;

namespace Query.Categories.GetByParentId;

public record GetCategoryByParentIdQuery(long parenId) : IQuery<List<ChildCategoryDto>>;