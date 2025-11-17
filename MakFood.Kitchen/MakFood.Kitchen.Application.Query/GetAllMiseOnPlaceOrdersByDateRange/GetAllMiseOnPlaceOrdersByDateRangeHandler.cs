using MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrdersByDateRange;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrderByDateRange
{
    public class GetAllMiseOnPlaceOrdersByDateRangeHandler : IRequestHandler<GetAllMiseOnPlaceOrdersByDateRangeQuery, GetAllMiseOnPlaceOrdersByDateRangeResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllMiseOnPlaceOrdersByDateRangeHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetAllMiseOnPlaceOrdersByDateRangeResponse> Handle(GetAllMiseOnPlaceOrdersByDateRangeQuery request, CancellationToken ct)
        {
           var ordersFromTargetRange = await _orderRepository.GetOrderByDateRangeAsync(request.FromDate, request.ToDate, ct);

           var AllMiseOnPlaceOrdersByDateRange = ordersFromTargetRange.Select( x => new GetAllMiseOnPlaceOrdersByDateRangeDto(
               x.CustomerId,
               x.DiscountCode,
               x.DiscountPrice,
               x.Price,
               x.Payable,
               x.Payment
               )).ToList();

            var result = new GetAllMiseOnPlaceOrdersByDateRangeResponse(AllMiseOnPlaceOrdersByDateRange);

            return result;
        }
    }
}
