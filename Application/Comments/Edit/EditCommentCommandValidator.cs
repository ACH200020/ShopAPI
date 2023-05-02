using Common.Application.Validation;
using FluentValidation;

namespace Application.Comments.Edit;

public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
{
    public EditCommentCommandValidator()
    {
        RuleFor(s => s.Text).NotNull().MinimumLength(5)
            .WithMessage(ValidationMessages.minLength("متن مورد نظر", 5));
    }
}