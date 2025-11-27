using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;

namespace MakFood.Kitchen.Domain.DomainService.PayOrderService
{
    public interface IPayService
    {
        public Task payOrder(Order order, Guid userId, CancellationToken ct);
    }
}
