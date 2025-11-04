using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class OrderStateConfiguration : IEntityTypeConfiguration<OrderState>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderState> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.HasDiscriminator()
                   .HasValue<CancelledOrderState>(nameof(CancelledOrderState))
                   .HasValue<CreatedOrderState>(nameof(CreatedOrderState))
                   .HasValue<MiseOnPlaceOrderState>(nameof(MiseOnPlaceOrderState));
        }
    }
}
