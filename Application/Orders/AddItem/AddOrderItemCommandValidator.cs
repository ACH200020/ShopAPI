using FluentValidation;

namespace Application.Orders.AddItem;

public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
{
    public AddOrderItemCommandValidator()
    {
        RuleFor(f => f.Count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}