using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate
{
    public class Constituent : BaseEntity<Guid>
    {
        private Constituent() { }//ef
        public Constituent(Product product,CartItem cartItem)
        {
            Check(new NameMustContainOnlyValidCharactersBR(product.Name));
            Check(new PriceMustBePositiveBR(product.Price));
            Id = Guid.NewGuid();
            Name = product.Name;
            Price = product.Price;
            ProductId = product.Id;
            Quantity = cartItem.Quantity;
        }



        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Guid ProductId { get; private set; }
        public uint Quantity { get; private set; }

    }
}
