using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;
using System.Text.RegularExpressions;


namespace MakFood.Kitchen.Domain.Entities.CartAggrigate
{
    public class CartItem : BaseEntity<Guid>
    {
        private CartItem() //ef
        {
            
        }
        public CartItem(string prodoctName, string prodoctThumbnailPath, Guid productId, uint quantity)
        {
            validateName(prodoctName);
            ProdoctName = prodoctName;
            ProdoctThumbnailPath = prodoctThumbnailPath;
            ProductId = productId;
            Quantity = quantity;
        }
        public CartItem(string prodoctName, string prodoctThumbnailPath, Guid productId)
        {
            validateName(prodoctName);
            ProdoctName = prodoctName;
            ProdoctThumbnailPath = prodoctThumbnailPath;
            ProductId = productId;
            Quantity = 1;
        }
        public CartItem(Product product)
        {
            validateName(product.Name);
            ProdoctName = product.Name;
            ProdoctThumbnailPath = product.ThumbnailPath;
            ProductId = product.Id;
            Quantity = 1;
        }
        public CartItem(Product product, uint quantity)
        {
            validateName(product.Name);
            ProdoctName = product.Name;
            ProdoctThumbnailPath = product.ThumbnailPath;
            ProductId = product.Id;
            Quantity = quantity;
        }


        public string ProdoctName { get; private init; }
        public string ProdoctThumbnailPath { get; private init; }
        public Guid ProductId { get; private init; }
        public uint Quantity { get; private set; }


        #region Vadiations
        private void validateName(String name)
        {
            var regex = new Regex(@"^[a-zA-Z\s\-_]{1,25}$");
            if (!regex.IsMatch(name)) { throw new Exception("your string is not in valid form only a-z , A-Z, Space and _ or - is valid"); }
        }

        #endregion

        #region Behaviors
        public void IncreaseQuantity()
        {
            Quantity += 1;
        }

        public void DecreaseQuantity()
        {
            if (1 > Quantity) { throw new Exception($"you can't do this, is more then your Quantity {Quantity}"); }
            Quantity -= 1;
        }
        #endregion
    }

}


