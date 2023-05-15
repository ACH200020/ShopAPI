using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;

namespace Infrastructure.Persistent.EF.OrderAgg;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", "order");
        builder.HasKey(x => x.Id);

        builder.HasIndex(b => b.UserId);

        builder.OwnsMany(b => b.Items, config =>
        {
            config.ToTable("Items", "order");
            config.HasKey(b => b.Id);
            config.HasIndex(b => b.InventoryId);
            config.HasIndex(b => b.OrderId);
        });

        builder.OwnsOne(b => b.ShippingMethod, config =>
        {
            config.Property(b => b.ShippingType)
                .IsRequired(false)
                .HasMaxLength(100);
        });

        builder.OwnsOne(b => b.Address, config =>
        {
            config.HasKey(b => b.Id);
            config.ToTable("Addresses", "order");

            config.Property(b => b.Shire)
                .IsRequired().HasMaxLength(100);

            config.Property(b => b.City)
                .IsRequired().HasMaxLength(100);

            config.Property(b => b.Name)
                .IsRequired().HasMaxLength(50);

            config.Property(b => b.Family)
                .IsRequired().HasMaxLength(50);

            config.Property(b => b.PhoneNumber)
                .IsRequired().HasMaxLength(12);

            config.Property(b => b.NationalCode)
                .IsRequired().HasMaxLength(10);

            config.Property(b => b.PostalCode)
                .IsRequired().HasMaxLength(20);
        });

        builder.OwnsOne(b => b.Discount, config =>
        {
            config.Property(b => b.DiscountTitle)
                .IsRequired()
                .HasMaxLength(100);
        });
    }
}