using Common.Domain.Repository;

namespace Domain.CommentAgg.Repository;

public interface ICommentRepository : IBaseRepository<Comment>
{
    Task DeleteAndSave(Comment comment);
}