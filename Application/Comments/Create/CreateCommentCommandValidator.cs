using Common.Application.Validation;
using FluentValidation;

namespace Application.Comments.Create;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(s => s.Text).NotNull().MinimumLength(5)
            .WithMessage(ValidationMessages.minLength("متن مورد نظر",5));
    }
}