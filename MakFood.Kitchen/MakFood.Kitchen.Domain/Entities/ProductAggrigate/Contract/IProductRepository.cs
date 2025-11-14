namespace MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract
{
    public interface IProductRepository
    {
        public Task<Product> GetProduct(Guid prodactId, CancellationToken ct, bool needToTrack = true);
    }
}
