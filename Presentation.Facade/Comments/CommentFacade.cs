using Application.Comments.ChangeStatus;
using Application.Comments.Create;
using Application.Comments.Delete;
using Application.Comments.Edit;
using Common.Application;
using MediatR;
using Query.Comments.DTOs;
using Query.Comments.GetByFilter;
using Query.Comments.GetById;

namespace Presentation.Facade.Comments;

internal class CommentFacade : ICommentFacade
{
    private readonly IMediator _mediator;

    public CommentFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> CreateCommend(CreateCommentCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> EditComment(EditCommentCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> DeleteComment(DeleteCommentCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<CommentDto?> GetCommentById(long id)
    {
        return await _mediator.Send(new GetCommentByIdQuery(id));
    }

    public async Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filter)
    {
        return await _mediator.Send(new GetCommentByFilterQuery(filter));

    }
}