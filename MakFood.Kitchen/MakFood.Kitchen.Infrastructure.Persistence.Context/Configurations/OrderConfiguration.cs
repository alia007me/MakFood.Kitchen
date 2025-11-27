using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).ValueGeneratedNever();

            builder.Property(o => o.CustomerId).IsRequired();

            builder.Property(o => o.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

            builder.Property(o => o.DiscountPrice)
                    .HasColumnType("decimal(18,2)");

            builder.Property(o => o.Payable)
                    .HasColumnType("decimal(18,2)");

            builder.HasOne(o => o.DiscountCode)
                    .WithMany()
                    .HasForeignKey("DiscountCodeId")
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Payment)
                    .WithOne()
                    .HasForeignKey<Order>("PaymentId")
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.Consistencies)
                    .WithOne()
                    .HasForeignKey("OrderId")
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(j => j.StateHistory)
                    .WithOne()
                    .HasForeignKey("OrderId")
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}