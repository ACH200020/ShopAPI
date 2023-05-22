using Common.Query;
using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.Categories.DTOs;

namespace Query.Categories.GetById;

public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ShopContext _context;

    public GetCategoryByIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories
            .FirstOrDefaultAsync(f => f.Id == request.CategoryId, cancellationToken);
        return model.Map();

    }
}