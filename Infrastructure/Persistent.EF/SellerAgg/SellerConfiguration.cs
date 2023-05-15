using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SellerAgg;

namespace Infrastructure.Persistent.EF.SellerAgg;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.ToTable("Sellers", "seller");
        builder.HasIndex(b => b.NationalCode).IsUnique();

        builder.Property(b => b.NationalCode)
            .IsRequired();

        builder.Property(b => b.ShopName)
            .IsRequired();

        builder.OwnsMany(b => b.Inventories, config =>
        {
            config.ToTable("Inventories", "Seller");
            config.HasKey(b => b.Id);
            config.HasIndex(b => b.ProductId);
            config.HasIndex(b => b.SellerId);
        });

    }
}