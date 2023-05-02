using Common.Application;

namespace Application.Comments.Edit;

public record EditCommentCommand(long CommentId, string Text, long UserId) : IBaseCommand;