using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;


namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                   .ValueGeneratedNever();

            builder.Property(ci => ci.ProductName)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.Property(ci => ci.ProductId).IsRequired();

            builder.Property(ci => ci.ProductThumbnailPath).IsRequired();

            builder.Property(ci => ci.Quantity).IsRequired();
        }
    }
}

