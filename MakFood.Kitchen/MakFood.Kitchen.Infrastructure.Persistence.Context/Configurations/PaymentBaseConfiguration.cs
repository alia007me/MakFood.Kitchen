using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class PaymentBaseConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.TotalAmount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

            builder.Property(p => p.ReminingAmount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

            builder.Property(p => p.OwnerPaymentMethod)
                    .HasConversion<string>()
                    .IsRequired();

            builder.Property(p => p.OwnerAmount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

            builder.Property(p => p.OwnerPaidAmount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

            builder.Property(p => p.OwnerPaidTime)
                    .IsRequired(false);

            builder.Property(p => p.PaymentType)
                    .IsRequired();

            builder.Property(p => p.OwnerId)
                    .IsRequired();

            builder.HasDiscriminator<string>("PaymentDiscriminator")
                .HasValue<SinglePayment>(nameof(PaymentType.Single))
                .HasValue<SharedPayment>(nameof(PaymentType.Shared));

            builder.HasMany(p => p.PaymentLog)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey("PaymentId");

        }
    }
}