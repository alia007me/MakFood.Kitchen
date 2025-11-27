namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrderByDateRangeAsync(DateOnly FromDate, DateOnly ToDate, CancellationToken ct);
        public Task<Order?> GetOrderByIdAsync(Guid orderId, CancellationToken ct);
        public Task<IEnumerable<GetProductOrderCountsReadModel>> GetProductOrderCountsByDateRange(DateOnly FromDate, DateOnly ToDate, CancellationToken ct);
        public Task<decimal> GetTotalSalesByDate(DateOnly FromDate, DateOnly ToDate, CancellationToken ct);

        public class GetProductOrderCountsReadModel
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public long Count { get; set; }

        };

        public void AddOrder(Order order);
        public Task<long> GetTotalOrdersCountAsync(CancellationToken ct);
    }
}
