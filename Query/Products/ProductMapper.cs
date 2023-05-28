using System.Reflection.PortableExecutable;
using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.Products.DTOs;
using Shop.Domain.ProductAgg;

namespace Query.Products;

public static class ProductMapper
{
    public static ProductDto? Map(this Product? product)
    {
        if (product == null)
            return null;

        return new ProductDto()
        {
            Id = product.Id,
            CreationDate = product.CreationDate,
            Description = product.Description,
            ImageName = product.ImageName,
            SeoData = product.SeoData,
            Slug = product.Slug,
            Title = product.Title,
            Specifications = product.Specifications.Select(s => new ProductSpecificationDto()
            {
                Key = s.Key,
                Value = s.Value,

            }).ToList(),
            Images = product.Images.Select(s => new ProductImageDto()
            {
                Id = s.Id,
                ImageName = s.ImageName,
                CreationDate = s.CreationDate,
                ProductId = s.ProductId,
                Sequence = s.Sequence,
            }).ToList(),
            Category = new ProductCategoryDto()
            {
                Id = product.CategoryId,
            },
            SubCategory = new ProductCategoryDto()
            {
                Id = product.SubCategoryId,
            },
            SecondarySubCategory = product.SecondarySubCategoryId != null
                ? new ProductCategoryDto()
                {
                    Id = (long)product.SecondarySubCategoryId,
                }
                : null
        };
    }

    public static ProductFilterData MapListData(this Product product)
    {
        return new ProductFilterData()
        {
            Id = product.Id,
            CreationDate = product.CreationDate,
            ImageName = product.ImageName,
            Slug = product.Slug,
            Title = product.Title,
        };

    }


    public static async Task SetCategories(this ProductDto product, ShopContext context)
    {
        var categories = await context.Categories
            .Where(r => r.Id == product.Category.Id || r.Id == product.SubCategory.Id)
            .Select(s => new ProductCategoryDto()
            {
                Id = s.Id,
                Slug = s.Slug,
                Title = s.Title,
                ParentId = s.ParentId,
                SeoData = s.SeoData
            }).ToListAsync();
        if (product.SecondarySubCategory != null)
        {
            var secondarySubCategory = await context.Categories
                .Where(f => f.Id == product.SecondarySubCategory.Id)
                .Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    Slug = s.Slug,
                    Title = s.Title,
                    ParentId = s.ParentId,
                    SeoData = s.SeoData

                }).FirstOrDefaultAsync();
            if (secondarySubCategory != null)
            {
                product.SecondarySubCategory = secondarySubCategory;
            }
        }

        product.Category = categories.First(r => r.Id == product.Category.Id);
        product.SubCategory = categories.First(r=>r.Id == product.SubCategory.Id);
    }
}