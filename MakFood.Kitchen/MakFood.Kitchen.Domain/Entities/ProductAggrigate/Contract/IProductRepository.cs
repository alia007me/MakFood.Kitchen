namespace MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract
{
    public interface IProductRepository
    {
        public Task<Product> GetProduct(Guid prodactId, CancellationToken ct, bool needToTrack = true);
    
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
        Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct = default);
    } 
}
