using Common.Application;
using FluentValidation;

namespace Application.Categories.Remove;

public record RemoveCategoryCommand(long Id) : IBaseCommand;