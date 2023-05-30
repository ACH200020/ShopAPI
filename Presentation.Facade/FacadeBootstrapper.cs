using Microsoft.Extensions.DependencyInjection;
using Presentation.Facade.Categories;
using Presentation.Facade.Comments;
using Presentation.Facade.Orders;
using Presentation.Facade.Products;
using Presentation.Facade.Roles;
using Presentation.Facade.Sellers;
using Presentation.Facade.Sellers.Inventories;
using Presentation.Facade.SiteEntities.Banner;
using Presentation.Facade.SiteEntities.ShippingMethod;
using Presentation.Facade.SiteEntities.Slider;
using Presentation.Facade.Users.Addresses;
using Presentation.Facade.Users;

namespace Presentation.Facade;

public static class FacadeBootstrapper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        services.AddScoped<ICommentFacade, CommentFacade>();
        services.AddScoped<IOrderFacade, OrderFacade>();
        services.AddScoped<IProductFacade, ProductFacade>();
        services.AddScoped<IRoleFacade, RoleFacade>();
        services.AddScoped<ISellerFacade, SellerFacade>();
        services.AddScoped<IBannerFacade, BannerFacade>();
        services.AddScoped<ISliderFacade, SliderFacade>();
        services.AddScoped<ISellerInventoriesFacade, SellerInventoriesFacade>();
        services.AddScoped<IShippingMethodFacade, ShippingMethodFacade>();

        services.AddScoped<IUserFacade, UserFacade>();
        services.AddScoped<IUserAddressesFacade, UserAddressesFacade>();
    }
}