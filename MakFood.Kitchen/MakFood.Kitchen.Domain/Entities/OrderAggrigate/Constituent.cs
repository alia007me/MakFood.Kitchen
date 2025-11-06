using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate
{
    public class Constituent : BaseEntity<Guid>
    {
        public Constituent(string name, decimal price, Guid productId)
        {
            Check(new NameMustContainOnlyValidCharactersBR(name));
            Check(new PriceMustBePositiveBR(price));
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            this.ProductId = productId;
        }

        public Constituent(Product product)
        {
            Check(new NameMustContainOnlyValidCharactersBR(product.Name));
            Check(new PriceMustBePositiveBR(product.Price));
            Id = Guid.NewGuid();
            Name = product.Name;
            Price = product.Price;
            ProductId = product.Id;
        }



        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Guid ProductId { get; private set; }

    }
}
