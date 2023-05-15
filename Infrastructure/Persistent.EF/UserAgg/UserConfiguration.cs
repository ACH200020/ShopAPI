using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAgg;

namespace Infrastructure.Persistent.EF.UserAgg;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "User");
        builder.HasIndex(b => b.PhoneNumber).IsUnique();
        builder.HasIndex(b => b.Email).IsUnique();

        builder.Property(b => b.Email)
            .IsRequired(false)
            .HasMaxLength(256);

        builder.Property(b => b.PhoneNumber)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(b => b.Name)
            .IsRequired(false)

            .HasMaxLength(80);

        builder.Property(b => b.Family)
            .IsRequired(false)
            .HasMaxLength(80);

        builder.Property(b => b.Password)
            .IsRequired()
            .HasMaxLength(50);


        builder.OwnsMany(b => b.Addresses, config =>
        {
            config.HasIndex(b => b.UserId);
            config.ToTable("Addresses", "user");

            config.Property(b => b.Shire)
                .IsRequired().HasMaxLength(100);

            config.Property(b => b.City)
                .IsRequired().HasMaxLength(100);

            config.Property(b => b.Name)
                .IsRequired().HasMaxLength(50);

            config.Property(b => b.Family)
                .IsRequired().HasMaxLength(50);


            config.Property(b => b.NationalCode)
                .IsRequired().HasMaxLength(10);

            config.Property(b => b.PostalCode)
                .IsRequired().HasMaxLength(20);

            config.OwnsOne(b => b.PhoneNumber, option =>
            {
                option.Property(b => b.Value)
                    .HasColumnName("PhoneNumber")
                    .IsRequired().HasMaxLength(11);
            });

        });


        builder.OwnsMany(b => b.Wallets, config =>
        {
            config.ToTable("Wallets", "user");
            config.HasIndex(b => b.UserId);

            config.Property(b => b.Description)
                .IsRequired(false)
                .HasMaxLength(500);
        });

        builder.OwnsMany(b => b.Roles, config =>
        {
            config.ToTable("Roles", "user");
            config.HasIndex(b => b.UserId);
        });

    }
}