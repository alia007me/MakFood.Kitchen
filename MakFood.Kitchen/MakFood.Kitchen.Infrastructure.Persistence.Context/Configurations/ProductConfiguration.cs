using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.Name).IsRequired()
                                         .HasMaxLength(25);

            builder.Property(p => p.Description).IsRequired()
                                                .HasMaxLength(150);

            builder.Property(p => p.ThumbnailPath).IsRequired();

            builder.Property(p => p.AvailableQuantity).IsRequired();

            builder.Property(p => p.Price).HasColumnType("decimal(18,2)")
                                          .IsRequired();

            builder.Property(p => p.SubCategoryId).IsRequired();

            builder.Property(p => p.SubCategoryName).IsRequired();

        }

    }

}
