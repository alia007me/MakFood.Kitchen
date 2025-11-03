namespace MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract
{
    public interface IFoodRequestRepository
    {
        Task<bool> IsAlreadyExistAsync(Guid userId, Guid productId, DateOnly targetDate);
        Task AddFoodRequest(FoodRequest foodRequest);
    }
}
