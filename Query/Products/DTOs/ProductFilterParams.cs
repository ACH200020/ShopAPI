﻿using Common.Query.Filter;

namespace Query.Products.DTOs;

public class ProductFilterParams : BaseFilterParam
{
    public string? Title { get; set; }
    public long? Id { get; set; }
    public string? Slug { get; set; }
}