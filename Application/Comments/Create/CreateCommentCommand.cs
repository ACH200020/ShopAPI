using Common.Application;

namespace Application.Comments.Create;

public record CreateCommentCommand(string Text, long UserId, long ProductId) : IBaseCommand;