using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum; // نیاز به این using برای PaymentMathods
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class SharedPaymentConfiguration : IEntityTypeConfiguration<SharedPayment>
    {
        public void Configure(EntityTypeBuilder<SharedPayment> builder)
        {

            builder.Property(p => p.PartnerAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.PartnerId)
                .IsRequired();

            builder.Property(p => p.PartnerPaidAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();


            builder.Property(p => p.PartnerPaymentMethod)
                .HasConversion<string>() 
                .IsRequired(false);

            builder.Property(p => p.PartnerApproved)
                .IsRequired(false);
        }
    }
}