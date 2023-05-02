using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Application;
using Common.Domian.ValueObjects;

namespace Application.Categories.AddChild
{
    public record AddChildCategoryCommand
        (long ParentId, string Title, string Slug, SeoData SeoData) : IBaseCommand<long>;
}
