using Application._Utilities;
using Application.Categories;
using Application.Products;
using Application.Roles.Create;
using Application.Sellers;
using Application.Users;
using FluentValidation;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Facade;
using Query.Categories.GetById;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Services;


namespace Config;

public static class ShopBootstrapper
{
    public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Init(services, connectionString);

        services.AddMediatR(typeof(Directories).Assembly);

        services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

        services.AddTransient<IProductDomainService, ProductDomainService>();
        services.AddTransient<IUserDomainService, UserDomainService>();
        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<ISellerDomainService, SellerDomainService>();


        services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);

        services.InitFacadeDependency();


    }
}