using MakFood.Kitchen.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace MakFood.Kitchen.Domain.Cart
{
    public class CartItem : BaseEntity<Guid>
    {
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
            Quantity = 0;
        }


        public string ProdoctName { get; set; }
        public string ProdoctThumbnailPath { get; set; }
        public Guid ProductId { get; set; }
        public uint Quantity { get; set; }
        public void IncreaseQuantity(uint howMuch)
        {
            Quantity += howMuch;
        }
        public void DecreaseQuantity(uint howMuch)
        {
            if (howMuch > Quantity) { throw new Exception($"you can't do this is more then your {Quantity}"); }
            Quantity -= howMuch;
        }
        #region
            private static void validateName(String name) {
                var regex = new Regex(@"^[a-zA-Z\s\-_]{1,50}$");
            if (!regex.IsMatch(name)) { throw new Exception("your string is not in valid form only a-z , A-Z, Space and _ or - is valid"); }
            }
        #endregion
    }
}
