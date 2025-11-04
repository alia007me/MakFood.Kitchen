using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
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
                   .IsRequired();

            builder.Property(p => p.OwnerAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.OwnerPaidAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasMany(p => p.PaymentLog)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
