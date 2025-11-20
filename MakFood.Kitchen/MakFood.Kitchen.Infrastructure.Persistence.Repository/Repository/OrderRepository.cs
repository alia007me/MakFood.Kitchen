using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using OrderStatus = MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState.OrderStatus;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository
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
                                 .AsNoTracking()
                                 .Where(x => x.CreationDateTime >= startDateTime
                                          && x.CreationDateTime <= endDateTime)
                                 .Include(x => x.StateHistory)
                                 .Include(x => x.Consistencies)
                                 .Include(x => x.DiscountCode)
                                 .ThenInclude(p => p.DiscountPolicy)
                                 .Include(x => x.Payment)
                                 .ThenInclude(p => p.PaymentLog)
                                 .Where(c => c.StateHistory.OfType<MiseOnPlaceOrderState>().Any())
                                 .ToListAsync(ct);
        }

        public async Task<Order?> GetOrderByIdAsync(Guid orderId, CancellationToken ct)
        {
            return await _context.Orders
                .Include(x => x.StateHistory)
                .Include(x => x.Consistencies)
                .Include(x => x.DiscountCode)
                    .ThenInclude(p => p.DiscountPolicy)
                .Include(x => x.Payment)
                    .ThenInclude(p => p.PaymentLog)
                .FirstOrDefaultAsync(x => x.Id == orderId, ct);

        }

        public async Task<decimal> GetTotalSalesByDate(DateOnly FromDate, DateOnly ToDate, CancellationToken ct)
        {
            var startDateTime = FromDate.ToDateTime(TimeOnly.MinValue);
            var endDateTime = ToDate.ToDateTime(TimeOnly.MaxValue);

            return await _context.Orders
                                 .AsNoTracking()
                                 .Where(x => x.CreationDateTime >= startDateTime
                                          && x.CreationDateTime <= endDateTime)
                                 .Include(x => x.StateHistory)
                                 .Include(x => x.Consistencies)
                                 .Include(x => x.DiscountCode)
                                 .ThenInclude(p => p.DiscountPolicy)
                                 .Include(x => x.Payment)
                                 .ThenInclude(p => p.PaymentLog)
                                 .Where(c => c.StateHistory.OfType<MiseOnPlaceOrderState>().Any()).SumAsync(x => x.Payable, ct);
        }

        public async Task<IEnumerable<IOrderRepository.GetProductOrderCountsReadModel>> GetProductOrderCountsByDateRange(DateOnly FromDate, DateOnly ToDate, CancellationToken ct)
        {
            var startDateTime = FromDate.ToDateTime(TimeOnly.MinValue);
            var endDateTime = ToDate.ToDateTime(TimeOnly.MaxValue);

            return await _context.Orders.Where(x => x.CreationDateTime >= startDateTime
                                          && x.CreationDateTime <= endDateTime)
                .SelectMany(p => p.Consistencies)
                                          .GroupBy(g => new { g.ProductId, g.Name })
                                          .Select(x => new IOrderRepository.GetProductOrderCountsReadModel
                                          {
                                              ProductId = x.Key.ProductId,
                                              ProductName = x.Key.Name,
                                              Count = x.Sum(k => k.Quantity)
                                          }).ToListAsync(ct);
        }
    }
}
