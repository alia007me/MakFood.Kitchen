using Microsoft.VisualBasic;

namespace MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract
{
    public interface IFoodRequestRepository
    {
        Task<bool> IsAlreadyExistAsync(Guid userId, Guid productId, DateOnly targetDate,CancellationToken ct);
        Task AddFoodRequest(FoodRequest foodRequest);
        Task<IEnumerable<FoodRequest>> GetFoodRequestsByDateRangeAsync(DateOnly fromDate, DateOnly toDate, CancellationToken ct);
    }
}
