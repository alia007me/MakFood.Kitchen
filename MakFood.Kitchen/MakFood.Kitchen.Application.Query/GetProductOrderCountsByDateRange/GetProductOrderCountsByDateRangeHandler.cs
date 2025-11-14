using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetProductOrderCountsByDateRange
{
    public class GetProductOrderCountsByDateRangeHandler : IRequestHandler<GetProductOrderCountsByDateRangeQuery, List<GetProductOrderCountsByDateRangeDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetProductOrderCountsByDateRangeHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<GetProductOrderCountsByDateRangeDto>> Handle(GetProductOrderCountsByDateRangeQuery request, CancellationToken ct)
        {
            var ordersInDateRange = await _orderRepository.GetOrderByDateRangeAsync(request.FromDate, request.ToDate, ct);

            var result = ordersInDateRange.SelectMany(p => p.Consistencies)
                                          .GroupBy(g => new { g.ProductId,g.Name })
                                          .Select(x => new GetProductOrderCountsByDateRangeDto(
                                              x.Key.ProductId,
                                              x.Key.Name,
                                              x.Sum(k => k.Quantity)
                                              ))
                                          .ToList();

            return result;
        }
    }

}
