using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate;
using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using static MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract.IFoodRequestRepository;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository
{
    public class FoodRequestRepository : IFoodRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddFoodRequest(FoodRequest foodRequest)
        {
            _context.FoodRequests.Add(foodRequest);
        }

        public async Task<IEnumerable<GetAggregatedFoodRequestsReadModel>> GetFoodRequestsFoodCountByDateRangeAsync(DateOnly fromDate, DateOnly toDate, CancellationToken ct)
         {
            return await _context.FoodRequests
                            .Where(c => c.TargetDate >= fromDate && c.TargetDate <= toDate)
                            .GroupBy(c => c.ProductId)
                            .Select(c =>
                                new GetAggregatedFoodRequestsReadModel
                                {
                                    ProductId = c.Key,
                                    ProductName = c.First().ProductName,
                                    RequestedCount = c.Count()
                                })
                            .ToListAsync(ct);
        }

        public async Task<bool> IsAlreadyExistAsync(Guid userId, Guid productId, DateOnly targetDate, CancellationToken ct)
        {
            return await _context.FoodRequests
                .AsNoTracking()
                .AnyAsync(x => x.UserId == userId && x.ProductId == productId && x.TargetDate == targetDate, ct);
        }
    }
}
