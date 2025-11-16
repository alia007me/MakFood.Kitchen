namespace MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract
{
    public interface  IProductRepository
    {
        /// <summary>
        /// برسی می کند آیا محصول وجود دارد یا خیر
        /// </summary>
        /// <param name="productId">آیدی محصول</param>
        /// <returns>
        /// درست => در صورتی که محصول وجود داشته باشد/\
        /// نادرست => در صورتی که محصول وجود نداشته باشد
        /// </returns>
        Task<bool> IsExistByIdAsync(Guid productId);
        Task<bool> IsExistByIdNameThumbnailPathAsync(Guid productId,string productName,string productThumbnailPath);
        Task<bool> IsExistByIdNamePriceAsync(Guid productId, string productName, decimal price);
        /// <summary>
        /// اضافه کردن پروداکت جدید 
        /// </summary>
        /// <param name="product">پروداکت</param>
       public Task AddProductAsync(Product product);
        /// <summary>
        /// حذف کردن پروداکت
        /// </summary>
        /// <param name="product">پروداکت</param>
        public void RemoveProductAsync(Product product);
        /// <summary>
        /// اوردن پروداکت براساس ایدی پروداکت
        /// </summary>
        /// <param name="productId">ایدی پروداکت</param>
        /// <returns>پروداکت</returns>
        public Task<Product> GetByIdAsync(Guid productId);

    } 
}
