using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using OrderStatus = MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState.OrderStatus;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrderByDateRangeAsync(DateOnly FromDate, DateOnly ToDate, CancellationToken ct)
        {
            var startDateTime = FromDate.ToDateTime(TimeOnly.MinValue);
            var endDateTime = ToDate.ToDateTime(TimeOnly.MaxValue);

            return await _context.Orders
                                 .Where(x => x.CreationDateTime >= startDateTime
                                          && x.CreationDateTime <= endDateTime)
                                 .Include(x => x.StateHistory)
                                 .Include(x => x.Consistencies)
                                 .Include(x => x.DiscountCode)
                                 .ThenInclude(p => p.DiscountPolicy)
                                 .Include(x => x.Payment)
                                 .ThenInclude( p => p.PaymentLog)
                                 .Where(c => c.StateHistory.OfType<MiseOnPlaceOrderState>().Any())
                                 .ToListAsync(ct);


        }
    }
}
