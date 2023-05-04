using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Application.Sellers.Edit;

public class EditSellerCommandValidate : AbstractValidator<EditSellerCommand>
{
    public EditSellerCommandValidate()
    {
        RuleFor(r => r.ShopName)
            .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));
        RuleFor(r => r.NationalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("کدملی")).ValidNationalId();
    }
}