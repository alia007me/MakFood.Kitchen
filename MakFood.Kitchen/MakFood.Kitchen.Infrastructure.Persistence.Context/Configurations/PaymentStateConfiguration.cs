using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class PaymentStateConfiguration: IEntityTypeConfiguration<PaymentState>
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
