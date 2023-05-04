﻿using Common.Application.Validation;
using FluentValidation;

namespace Application.Roles.Create;

public class CreateRoleCommandValidator:AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}