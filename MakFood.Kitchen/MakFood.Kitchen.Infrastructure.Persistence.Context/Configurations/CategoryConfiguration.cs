using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property( c => c.Id).ValueGeneratedNever();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.HasMany(c => c.Subcategories)
                   .WithOne()
                   .HasForeignKey("CategoryId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.CreationDateTime).IsRequired();



        }
    }
}
