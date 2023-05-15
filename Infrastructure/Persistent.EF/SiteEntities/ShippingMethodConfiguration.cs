﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities;

namespace Infrastructure.Persistent.EF.SiteEntities;

public class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethod>
{
    public void Configure(EntityTypeBuilder<ShippingMethod> builder)
    {
        builder.Property(b => b.Title)
            .HasMaxLength(120).IsRequired();
    }
}