﻿using Application.Products.AddImage;
using Application.Products.Create;
using Application.Products.Edit;
using Application.Products.RemoveImage;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.Products;
using Query.Products.DTOs;
using ShopApi.ViewModels.Products;

namespace ShopApi.Controllers
{
   
    public class ProductController : ApiController
    {
        private readonly IProductFacade _productFacade;

        public ProductController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<ProductFilterResult>> GetProductByFilter([FromQuery] ProductFilterParams filterParams)
        {
            return QueryResult(await _productFacade.GetProductByFilter(filterParams));
        }
        [AllowAnonymous]
        [HttpGet("Shop")]
        public async Task<ApiResult<ProductShopResult>> GetProductForShopFilter([FromQuery] ProductShopFilterParam filterParams)
        {
            return QueryResult(await _productFacade.GetProductForShop(filterParams));
        }

        [AllowAnonymous]
        [HttpGet("{productId}")]
        public async Task<ApiResult<ProductDto?>> GetProductById(long productId)
        {
            var product = await _productFacade.GetProductById(productId);
            return QueryResult(product);
        }

        [AllowAnonymous]
        [HttpGet("bySlug/{slug}")]
        public async Task<ApiResult<ProductDto?>> GetProductBySlug(string slug)
        {
            var product = await _productFacade.GetProductBySlug(slug);
            return QueryResult(product);
        }

        [AllowAnonymous]
        [HttpGet("single/{slug}")]
        public async Task<ApiResult<SingleProductDto?>> GetSingleProduct(string slug)
        {
            var product = await _productFacade.GetProductBySlugForSinglePage(slug);
            return QueryResult(product);
        }

        [HttpPost]
        public async Task<ApiResult> CreateProduct([FromForm] CreateProductViewModel command)
        {
            var result = await _productFacade.CreateProduct(new CreateProductCommand()
            {
                SeoData = command.SeoData.Map(),
                CategoryId = command.CategoryId,
                Description = command.Description,
                ImageFile = command.ImageFile,
                SecondarySubCategoryId = command.SecondarySubCategoryId,
                Slug = command.Slug,
                Specifications = command.GetSpecification(),
                SubCategoryId = command.SubCategoryId,
                Title = command.Title
            });
            return CommandResult(result);
        }

        [HttpPost("images")]
        public async Task<ApiResult> AddImage([FromForm] AddProductImageCommand command)
        {
            var result = await _productFacade.AddImage(command);
            return CommandResult(result);
        }

        [HttpDelete("images")]
        public async Task<ApiResult> RemoveImage(RemoveProductImageCommand command)
        {
            var result = await _productFacade.RemoveImage(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditProduct([FromForm] EditProductViewModel command)
        {
            var result = await _productFacade.EditProduct(new EditProductCommand(command.ProductId, command.Title, command.ImageFile,
                command.Description, command.CategoryId, command.SubCategoryId, command.SecondarySubCategoryId, command.Slug, command.SeoData.Map(),
                command.GetSpecification()));

            return CommandResult(result);
        }
    }
}
