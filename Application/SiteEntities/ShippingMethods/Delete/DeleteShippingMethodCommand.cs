using Common.Application;
using FluentValidation;

namespace Application.SiteEntities.ShippingMethods.Delete;

public record DeleteShippingMethodCommand(long Id) : IBaseCommand
{
    
}