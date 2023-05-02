using Common.Application;
using Shop.Domain.CommentAgg;

namespace Application.Comments.Delete;

public record DeleteCommentCommand(long CommentId,long UserId) : IBaseCommand

public class DeleteCommentCommandHandler : IBaseCommandHandler<DeleteCommentCommand>
{
    private readonly ICommentRepository _repository;

    public DeleteCommentCommandHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetTracking(request.CommentId);
        if (result == null || result.UserId != request.UserId)
        {
            return OperationResult.NotFound();

        }

        await _repository.DeleteAndSave(result);
        return OperationResult.Success();
    }
}
