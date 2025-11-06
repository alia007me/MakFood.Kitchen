using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class FoodRequestConfiguration : IEntityTypeConfiguration<FoodRequest>
    {

        public void Configure(EntityTypeBuilder<FoodRequest> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).ValueGeneratedNever();

            builder.Property(f => f.UserId).IsRequired();

            builder.Property(f => f.ProductId).IsRequired();

            builder.Property(f => f.TargetDate).IsRequired();
        }
    }
}
