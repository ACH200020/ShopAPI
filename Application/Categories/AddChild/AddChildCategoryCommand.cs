using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Application;
using Common.Application.Validation;

using FluentValidation;
using Common.Domian.ValueObjects;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Application.Categories.AddChild
{
    public record AddChildCategoryCommand
        (long ParentId, string Title, string Slug, SeoData SeoData) : IBaseCommand<long>;


    internal class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand,long>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async  Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.ParentId);
            if (category == null)
                return OperationResult<long>.NotFound();

            category.AddChild(request.Title,request.Slug,request.SeoData,_domainService);
            await _repository.Save();
            return OperationResult<long>.Success(category.Id);
        }
    }

    public class AddChildCategoryCommandValidator : AbstractValidator<AddChildCategoryCommand>
    {
        public AddChildCategoryCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
