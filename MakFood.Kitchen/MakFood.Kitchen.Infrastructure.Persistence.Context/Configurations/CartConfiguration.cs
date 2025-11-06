using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(C => C.Id).ValueGeneratedNever();

            builder.HasMany(c => c.CartItems)
                   .WithOne()
                   .HasForeignKey("CartId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.CreationDateTime).IsRequired();
        }
    }
}
