using Infrastructure._Utilities;
using Shop.Domain.CommentAgg;

namespace Infrastructure.Persistent.EF.CommentAgg;

public class CommentRepository : BaseRepository<Comment>,ICommentRepository
{
    public CommentRepository(ShopContext context) : base(context)
    {
    }

    public async Task DeleteAndSave(Comment comment)
    {
        Context.Remove(comment);
        await Context.SaveChangesAsync();
    }
}