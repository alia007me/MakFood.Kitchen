using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;
using System.Text.RegularExpressions;



namespace MakFood.Kitchen.Domain.Entities.ProductAggrigate
{
    /// <summary>
    /// کلاس حاوی پروداکت
    /// </summary>
    public class Product : BaseEntity<Guid>
    {
        /// <summary>
        /// کانستراکتور پروداکت
        /// </summary>
        /// <param name="name">نام محصول</param>
        /// <param name="price">قیمت محصول</param>
        /// <param name="description">توضیحات محصول</param>
        /// <param name="thumbnailPath">آدرس تصویر محصول</param>
        /// <param name="productCategory">دسته بندی محصول</param>
        /// <param name="availableQuantity">مقدار موجود از محصول</param>
        public Product(string name, decimal price, string description,
            string thumbnailPath, Subcategory productCategory , uint availableQuantity)
        {
            NameValidation(name);
            PriceValidation(price);
            DescriptionValidation(description);
            ThumbnailPathValidation(thumbnailPath);
            


            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;
            ThumbnailPath = thumbnailPath;
            SubCategoryId = productCategory.Id;
            SubCategoryName = productCategory.Name;
            increaseQuantityValidator(availableQuantity);
        }
        private Product() //ef
        {
            
        }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public string ThumbnailPath { get; private set; }
        public Guid SubCategoryId { get; private set; }
        public string SubCategoryName { get; private set; }
        public uint AvailableQuantity { get; private set; }

        #region Validations

        private void NameValidation(string name)
        {
            name.CheckNullOrEmpty("name");
            var nameRegexPattern = "([A-Za-z\\s]{0,25})";
            if (Regex.IsMatch(nameRegexPattern, name)) throw new Exception("Product name may have invalid characters or more than 25 characters");
        }
        private void PriceValidation(decimal price)
        {
            price.CheckNullOrEmpty("price");
            if (Price < 0) throw new Exception("The product amount cannot be less than zero");
        }
        private void DescriptionValidation(string description)
        {
            description.CheckNullOrEmpty("description");
            var descriptionRegexPattern = "([A-Za-z\\s]{0,150})";
            if (!Regex.IsMatch(descriptionRegexPattern, description)) throw new Exception("The thumbnail path may contain invalid characters or exceed 150 characters");

        }
        private void ThumbnailPathValidation(string thumbnailPath)
        {
            thumbnailPath.CheckNullOrEmpty("thumbnailPath");
        }
        private void increaseQuantityValidator(decimal quantityToIncrease)
        {
            if (quantityToIncrease < 0) throw new Exception("The quantity to increase cannot be less than zero");
        }
        private void DecreaseQuantityValidator(decimal quantityToDecrease)
        {
            if (quantityToDecrease > AvailableQuantity) throw new Exception("The quantity to decrease exceeds the available quantity");
        }



        #endregion

        #region Behaviors

        /// <summary>
        /// نام پروداکت را آپدیت می کند
        /// </summary>
        /// <param name="newName">نام جدید پروداکت</param>
        public void UpdateProductName(string newName)
        {
            NameValidation(newName);
            Name = newName;
        }

        /// <summary>
        /// توضیحات محصول را آپدیت می کند
        /// </summary>
        /// <param name="newDescription">توضیحات محصول</param>
        public void UpdateDescription(string newDescription)
        {
            DescriptionValidation(newDescription);
            Description = newDescription;
        }

        /// <summary>
        /// مسیر تصویر محصول را آپدیت می کند
        /// </summary>
        /// <param name="thumbnailPath">مسیر تصویر محصول</param>
        public void UpdateThumbnailPath(string thumbnailPath)
        {
            ThumbnailPathValidation(thumbnailPath);
            ThumbnailPath = thumbnailPath;
        }

        /// <summary>
        /// دسته بندی محصول را آپدیت می کند
        /// </summary>
        /// <param name="subcategory">دسته بندی محصول</param>
        public void UpdateSubcategory(Subcategory subcategory)
        {
            SubCategoryId = subcategory.Id;
            SubCategoryName = subcategory.Name;    
        }

        /// <summary>
        /// قیمت محصول را آپدیت می کند
        /// </summary>
        /// <param name="newPrice">قیمت جدید محصول</param>
        public void UpdatePrice(decimal newPrice)
        {
            PriceValidation(Price);
            Price = newPrice;
        }

        /// <summary>
        /// تعداد موجودی محصول را افزایش می دهد
        /// </summary>
        /// <param name="quantityToIncrease">تعداد محصولات اضافه شده</param>
        public void IncreaseAvailableQuantity(uint quantityToIncrease)
        {
            increaseQuantityValidator(quantityToIncrease);
            AvailableQuantity += quantityToIncrease;
        }

        /// <summary>
        /// تعداد موجودی محصول را کاهش می دهد
        /// </summary>
        /// <param name="quantityToDecrease">تعداد محصولات کسر شده</param>
        public void DecreaseAvailableQuantity(uint quantityToDecrease)
        {
            DecreaseQuantityValidator(quantityToDecrease);
            AvailableQuantity -= quantityToDecrease;
        }

        #endregion

    }


}