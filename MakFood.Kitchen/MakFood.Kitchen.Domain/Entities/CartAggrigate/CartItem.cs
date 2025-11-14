using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;


namespace MakFood.Kitchen.Domain.Entities.CartAggrigate
{
    public class CartItem : BaseEntity<Guid>
    {
        const int DefaultCartItemQuantity = 1;
        private CartItem () {} //ef
        public CartItem(Product product)
        {
            Check(new ProductIdCannotBeEmptyBR(product.Id));
            Check(new NameMustContainOnlyValidCharactersBR(product.Name));
            Check(new ThumbnailPathCanNotBeWhitespaceBR(product.ThumbnailPath));
            Id = Guid.NewGuid();
            ProductName = product.Name;
            ProductThumbnailPath = product.ThumbnailPath;
            ProductId = product.Id;
            Quantity = DefaultCartItemQuantity;
        }

        public string ProductName { get; private init; }
        public string ProductThumbnailPath { get; private init; }
        public Guid ProductId { get; private init; }
        public uint Quantity { get; private set; }

        #region Behaviors
        public void IncreaseQuantity()
        {
            Quantity ++;
        }

        public void DecreaseQuantity()
        {
            Check(new QuantityCannotBeDecreasedBeyondAvailableBR(Quantity));
            Quantity--;
        }
        public bool IsReducible()
        {
            return Quantity > 1;
        }
        #endregion
    }

}


