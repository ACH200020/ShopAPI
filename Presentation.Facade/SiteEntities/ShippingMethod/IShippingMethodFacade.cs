using Application.SiteEntities.ShippingMethods.Create;
using Application.SiteEntities.ShippingMethods.Delete;
using Application.SiteEntities.ShippingMethods.Edit;
using Common.Application;
using Query.SiteEntities.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Presentation.Facade.SiteEntities.ShippingMethod;

public interface IShippingMethodFacade
{
    Task<OperationResult> Create(CreateShippingMethodCommand  command);
    Task<OperationResult> Edit(EditShippingMethodCommand  command);
    Task<OperationResult> Delete(long  id);

    Task<ShippingMethodDto?> GetShippingMethodById(long id);
    Task<List<ShippingMethodDto>> GetList();
}