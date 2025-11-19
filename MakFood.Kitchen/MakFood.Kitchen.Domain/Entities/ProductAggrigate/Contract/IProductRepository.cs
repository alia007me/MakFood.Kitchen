namespace MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract
{
    public interface IProductRepository
    {
        /// <summary>
        /// برسی می کند آیا محصول وجود دارد یا خیر
        /// </summary>
        /// <param name="productId">آیدی محصول</param>
        /// <returns>
        /// درست => در صورتی که محصول وجود داشته باشد/\
        /// نادرست => در صورتی که محصول وجود نداشته باشد
        /// </returns>
        Task<bool> IsExistByIdAsync(Guid productId, CancellationToken ct);
        Task<bool> IsExistByIdNameThumbnailPathAsync(Guid productId, string productName, string productThumbnailPath, CancellationToken ct);
        Task<bool> IsExistByIdNamePriceAsync(Guid productId, string productName, decimal price, CancellationToken ct);
        Task<Product?> GetProductByIdAsync(Guid productId, CancellationToken ct);

        public Task<Product> GetProduct(Guid prodactId, CancellationToken ct, bool needToTrack = true);
    }
}
