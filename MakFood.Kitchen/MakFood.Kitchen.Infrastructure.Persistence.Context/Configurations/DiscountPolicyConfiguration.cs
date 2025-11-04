using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.DiscountPolicyAggrigate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class DiscountPolicyConfiguration : IEntityTypeConfiguration<DiscountPolicy>
    {
        public void Configure(EntityTypeBuilder<DiscountPolicy> builder)
        {

            builder.HasDiscriminator<string>("DiscountPolicyType")
                   .HasValue<AllPermittedPolicy>(nameof(AllPermittedPolicy))
                   .HasValue<SpecifiedPermisionPolicy>(nameof(SpecifiedPermisionPolicy));

        }
    }
}
