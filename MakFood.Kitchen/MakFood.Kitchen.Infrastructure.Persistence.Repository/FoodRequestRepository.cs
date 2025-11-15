using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate;
using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository
{
    public class FoodRequestRepository : IFoodRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddFoodRequest(FoodRequest foodRequest)
        {
            _context.FoodRequests.Add(foodRequest);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<FoodRequest>> GetFoodRequestsByDateRangeAsync(DateOnly fromDate, DateOnly toDate, CancellationToken ct)
        {
            return await _context.FoodRequests
                .AsNoTracking()
                .Where(x => x.TargetDate >= fromDate && x.TargetDate <= toDate)
                .ToListAsync();
        }

        public async Task<bool> IsAlreadyExistAsync(Guid userId, Guid productId, DateOnly targetDate, CancellationToken ct)
        {
            return await _context.FoodRequests
                .AsNoTracking()
                .AnyAsync(x => x.UserId == userId && x.ProductId == productId && x.TargetDate == targetDate, ct);
        }
    }
}
