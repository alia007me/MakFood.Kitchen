namespace MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract
{
    public interface IProductRepository
    {
        Task<bool> IsExistByIdAsync(Guid productId,CancellationToken ct);
    } 
}
