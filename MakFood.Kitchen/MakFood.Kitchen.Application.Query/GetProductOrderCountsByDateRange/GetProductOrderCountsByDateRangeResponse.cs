using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;

namespace MakFood.Kitchen.Application.Query.GetProductOrderCountsByDateRange
{
    public record GetProductOrderCountsByDateRangeResponse(IEnumerable<IOrderRepository.GetProductOrderCountsReadModel> GetProductOrderCountsByDateRange);
}
