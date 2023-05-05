using Common.Application.Validation;
using FluentValidation;

namespace Application.Users.ChangeWallet;

public class ChangeUserWalletCommandValidator : AbstractValidator<ChangeUserWalletCommand>
{
    public ChangeUserWalletCommandValidator()
    {
        RuleFor(r => r.Description)
            .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

        RuleFor(r => r.Price)
            .GreaterThanOrEqualTo(1000);
    }
}