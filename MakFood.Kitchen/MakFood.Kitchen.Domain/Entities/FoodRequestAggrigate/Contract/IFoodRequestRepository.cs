using Microsoft.VisualBasic;

namespace MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract
{
    public interface IFoodRequestRepository
    {
        Task<bool> IsAlreadyExistAsync(Guid userId, Guid productId, DateOnly targetDate,CancellationToken ct);
        void AddFoodRequest(FoodRequest foodRequest);
        Task<IEnumerable<GetAggregatedFoodRequestsReadModel>> GetFoodRequestsFoodCountByDateRangeAsync(DateOnly fromDate, DateOnly toDate, CancellationToken ct);

        public record GetAggregatedFoodRequestsReadModel
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public int RequestedCount { get; set; }
        }
    }
}
