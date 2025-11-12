using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;
using System.Text.RegularExpressions;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate
{
    public class Constituent : BaseEntity<Guid>
    {
        private Constituent() { }//ef
        public Constituent(string name, decimal price, Guid productId)
        {

            validateName(name);
            validatePrice(price);
            Id = Guid.NewGuid();    
            Name = name;
            Price = price;
            this.ProductId = productId;
        }


        public Constituent(Product product, CartItem cartItem)
        {
            validateName(product.Name);
            validatePrice(product.Price);
            Id = Guid.NewGuid();
            Name = product.Name;
            Price = product.Price;
            ProductId = product.Id;
            Quantity = cartItem.Quantity;
        }




        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Guid ProductId { get; private set; }
        public uint Quantity { get;private init; }
        #region Validations
        private static void validateName(String name)
        {
            var regex = new Regex(@"^[a-zA-Z\s\-_]{1,50}$");
            if (!regex.IsMatch(name)) { throw new Exception("your string is not in valid form only a-z , A-Z, Space and _ or - is valid"); }
        }
        private static void validatePrice(decimal price)
        {
            price.CheckNullOrEmpty("price");
            if (price < 0) { throw new Exception("the price shoud be a posetive number"); }
        }
        #endregion
    }
}
