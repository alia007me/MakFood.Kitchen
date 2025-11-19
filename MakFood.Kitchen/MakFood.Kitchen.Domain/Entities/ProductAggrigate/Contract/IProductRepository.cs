
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
        Task<bool> IsExistByIdAsync(Guid productId);
        Task<bool> IsExistByIdNameThumbnailPathAsync(Guid productId, string productName, string productThumbnailPath);
        Task<bool> IsExistByIdNamePriceAsync(Guid productId, string productName, decimal price);
        Task<IEnumerable<GetFilteredProductsReadModel>> FilterAsync(string? name, Guid? categoryId, Guid? subcategoryId, CancellationToken ct);
        Task<bool> HasProductsInSubcategoriesAsync(Guid subcategoryId, CancellationToken ct);
        Task<bool> HasProductsInCategoryAsync(Guid categoryId, CancellationToken ct);

        public class GetFilteredProductsReadModel
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public string SubCategoryName { get; set; }
        }
    
        public Task<Product> GetProduct(Guid prodactId, CancellationToken ct, bool needToTrack = true);
    }
}
