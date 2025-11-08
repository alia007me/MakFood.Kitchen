using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;


namespace MakFood.Kitchen.Domain.Entities.CartAggrigate
{
    public class CartItem : BaseEntity<Guid>
    {
        private CartItem() //ef
        {
            
        }
        public CartItem(string productName, string productThumbnailPath, Guid productId, uint quantity)
        {
            Check(new ProductIdCannotBeEmptyBR(productId));
            Check(new NameMustContainOnlyValidCharactersBR(productName));
            Check(new ThumbnailPathCanNotBeWhitespaceBR(productThumbnailPath));

            ProductName = productName;
            ProductThumbnailPath = productThumbnailPath;
            ProductId = productId;
            Quantity = quantity;
        }
        public CartItem(string productName, string productThumbnailPath, Guid productId)
        {
            Check(new ProductIdCannotBeEmptyBR(productId));
            Check(new NameMustContainOnlyValidCharactersBR(productName));
            Check(new ThumbnailPathCanNotBeWhitespaceBR(productThumbnailPath));

            ProductName = productName;
            ProductThumbnailPath = productThumbnailPath;
            ProductId = productId;
            Quantity = 1;
        }
        public CartItem(Product product)
        {
            Check(new ProductIdCannotBeEmptyBR(product.Id));
            Check(new NameMustContainOnlyValidCharactersBR(product.Name));
            Check(new ThumbnailPathCanNotBeWhitespaceBR(product.ThumbnailPath));

            ProductName = product.Name;
            ProductThumbnailPath = product.ThumbnailPath;
            ProductId = product.Id;
            Quantity = 1;
        }
        public CartItem(Product product, uint quantity)
        {
            Check(new ProductIdCannotBeEmptyBR(product.Id));
            Check(new NameMustContainOnlyValidCharactersBR(product.Name));
            Check(new ThumbnailPathCanNotBeWhitespaceBR(product.ThumbnailPath));

            ProductName = product.Name;
            ProductThumbnailPath = product.ThumbnailPath;
            ProductId = product.Id;
            Quantity = quantity;
        }


        public string ProductName { get; private init; }
        public string ProductThumbnailPath { get; private init; }
        public Guid ProductId { get; private init; }
        public uint Quantity { get; private set; }

        #region Behaviors
        public void IncreaseQuantity(uint quantityToIncrease)
        {
            Check(new IncreaseQuantityMustBeGreaterThanZeroBR(quantityToIncrease));
            Quantity += quantityToIncrease;
        }

        public void DecreaseQuantity(uint quantityToDecrease)
        {
            Check(new QuantityCannotBeDecreasedBeyondAvailableBR(Quantity,quantityToDecrease));
            Quantity -= quantityToDecrease;
        }
        #endregion
    }

}


