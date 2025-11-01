using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;


namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class CarItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).ValueGeneratedNever();

            builder.Property(ci => ci.ProdoctName)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.Property(ci => ci.ProductId).IsRequired();
            builder.Property(ci => ci.ProdoctThumbnailPath).IsRequired();

            builder.Property(ci => ci.Quantity).IsRequired();

            builder.Property(ci => ci.CreationDateTime).IsRequired();

        }
    }
}
