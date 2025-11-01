using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).ValueGeneratedNever();

            builder.Property(d => d.Title)
                  .IsRequired()
                   .HasMaxLength(25);

            builder.Property(d => d.Percent)
                   .IsRequired();

            builder.Property(d => d.ExpiryDate)
                   .IsRequired();

            builder.Property(d => d.MaximumBalance)
                   .HasColumnType("decimal(18,2)");

            builder.Property(d => d.MinimumBalance)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(d => d.DiscountPolicy)
               .WithOne()
               .HasForeignKey<Discount>("DiscountPolicyId") 
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

           

        }
    }
}
