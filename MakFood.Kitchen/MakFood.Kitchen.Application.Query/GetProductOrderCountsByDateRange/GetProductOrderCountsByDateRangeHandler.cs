using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetProductOrderCountsByDateRange
{
    public class GetProductOrderCountsByDateRangeHandler : IRequestHandler<GetProductOrderCountsByDateRangeQuery, GetProductOrderCountsByDateRangeResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetProductOrderCountsByDateRangeHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetProductOrderCountsByDateRangeResponse> Handle(GetProductOrderCountsByDateRangeQuery request, CancellationToken ct)
        {
            var getProductOrderCountsByDateRange = await _orderRepository.GetProductOrderCountsByDateRange(request.FromDate, request.ToDate, ct);

            var result = new GetProductOrderCountsByDateRangeResponse(getProductOrderCountsByDateRange);

            return result;
        }
    }

}
