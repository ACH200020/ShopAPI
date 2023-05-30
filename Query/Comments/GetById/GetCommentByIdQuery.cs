using Common.Query;
using Query.Comments.DTOs;

namespace Query.Comments.GetById;

public record GetCommentByIdQuery(long commentId) : IQuery<CommentDto?>;