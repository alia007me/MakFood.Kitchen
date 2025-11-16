using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrderByDateRangeAsync(DateOnly FromDate,DateOnly ToDate,CancellationToken ct);
        public Task<Order?> GetOrderByIdAsync(Guid orderId,CancellationToken ct);
        public void AddOrder(Order order);
    }
}
