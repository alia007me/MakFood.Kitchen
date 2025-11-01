using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;


namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.HasKey(s=> s.Id);
            builder.Property(s => s.Id).ValueGeneratedNever();
            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength (25);
            builder.Property(s => s.CategoryId)
        }
    }
}
