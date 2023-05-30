using Common.Query;
using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.Comments.DTOs;

namespace Query.Comments.GetById;

public class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery,CommentDto?>
{
    private readonly ShopContext _context;

    public GetCommentByIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(f => f.Id == request.commentId,
            cancellationToken: cancellationToken);
        return comment.Map();
    }
}