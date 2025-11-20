namespace MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(Guid prodactId, CancellationToken ct, bool needToTrack = true);
        Task<bool> HasProductsInSubcategoriesAsync(Guid subcategoryId, CancellationToken ct);
        Task<bool> HasProductsInCategoryAsync(Guid categoryId, CancellationToken ct);

       

        
    
}
}
