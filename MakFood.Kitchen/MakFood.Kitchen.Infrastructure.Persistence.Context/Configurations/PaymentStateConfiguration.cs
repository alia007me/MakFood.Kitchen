using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class PaymentStateConfiguration : IEntityTypeConfiguration<PaymentState>
    {
        public void Configure(EntityTypeBuilder<PaymentState> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.HasDiscriminator()
                   .HasValue<CancelledPaymentState>(nameof(CancelledPaymentState))
                   .HasValue<CreatedPaymentState>(nameof(CreatedPaymentState))
                   .HasValue<PaidPaymentState>(nameof(PaidPaymentState));
        }
    }
}
