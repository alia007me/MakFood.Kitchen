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

        public async Task<List<Order>> GetOrderByCustomerIdAsync(Guid CustomerId, DateTime StartDateTime, DateTime EndDateTime)
        {
            return await _context.Orders
                .Where(w => w.CustomerId == CustomerId && w.CreationDateTime >= StartDateTime && w.CreationDateTime <= EndDateTime && w.StateHistory.OfType<MiseOnPlaceOrderState>().Any())
                .OrderByDescending(w=>w.CreationDateTime)
                .ToListAsync();
           
        }
    }
}
