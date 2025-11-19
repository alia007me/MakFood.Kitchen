using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Runtime.InteropServices.Marshalling;


namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        public readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrderByCustomerIdAsyncs(Guid CustomerId, DateTime StartDateTime, DateTime EndDateTime, CancellationToken cancellationToken)
        {
            return await _context.Orders
                .Where(w => w.CustomerId == CustomerId)
                .Where(w=>w.CreationDateTime >= StartDateTime && w.CreationDateTime <= EndDateTime)
                .Include(w=>w.StateHistory)
                .Include(w=>w.Consistencies)
                .Include(w=>w.DiscountCode)
                .Include(w=>w.Payment)
                .Where(w=>w.StateHistory.OfType<MiseOnPlaceOrderState>().Any())
                .OrderByDescending(w=>w.CreationDateTime)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
           
        }
    }
}
