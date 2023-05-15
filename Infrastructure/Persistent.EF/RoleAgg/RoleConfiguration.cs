﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RoleAgg;

namespace Infrastructure.Persistent.EF.RoleAgg;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles", "role");

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(60);

        builder.OwnsMany(b => b.Permissions, config =>
        {
            config.ToTable("Permissions", "role");
        });
    }
}