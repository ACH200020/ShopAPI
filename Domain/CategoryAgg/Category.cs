using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Domain.CategoryAgg.Services;

namespace Domain.CategoryAgg;

public class Category : AggregateRoot
{
    public Category()
    {
        Childs = new List<Category>();
    }
    public Category(string slug, SeoData seoData, string title, ICategoryDomainService service)
    {
        slug = slug?.ToSlug();
        Guard(title, slug, service);

        Slug = slug;
        SeoData = seoData;
        Title = title;
        Childs = new List<Category>();
    }
    public long? ParentId { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public string Title { get; private set; }
    public List<Category> Childs { get; private set; }

    public void Edit(string slug, SeoData seoData, string title, ICategoryDomainService service)
    {
        slug = slug?.ToSlug();
        Guard(title, slug, service);

        Slug = slug;
        SeoData = seoData;
        Title = title;
    }

    public void AddChild(string title, string slug,SeoData seoData ,ICategoryDomainService service)
    {
        Childs.Add(new Category(slug,seoData,title,service)
        {
            ParentId = Id
        });
    }

    public void Guard(string title, string slug, ICategoryDomainService service)
    {
        NullOrEmptyDomainDataException.CheckString(title,nameof(title));
        NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

        if (slug != Slug)
        {
            if (service.IsSlugExist(slug))
            {
                throw new SlugIsDuplicateException();
            }
        }
    }
}