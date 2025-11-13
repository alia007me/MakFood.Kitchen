namespace MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract
{
    public interface IProductRepository
    {
        public Task<Product> GetProductTracked(Guid prodactId, CancellationToken ct);
        public Task<Product> GetProduct(Guid prodactId, CancellationToken ct);
    }
}