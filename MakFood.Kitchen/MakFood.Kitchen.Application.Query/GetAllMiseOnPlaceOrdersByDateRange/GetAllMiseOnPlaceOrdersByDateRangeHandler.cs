using MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrderByDateRange;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrderByDateRange
{
    public class GetAllMiseOnPlaceOrdersByDateRangeHandler : IRequestHandler<GetAllMiseOnPlaceOrdersByDateRangeQuery, IEnumerable<GetAllMiseOnPlaceOrdersByDateRangeDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllMiseOnPlaceOrdersByDateRangeHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<GetAllMiseOnPlaceOrdersByDateRangeDto>> Handle(GetAllMiseOnPlaceOrdersByDateRangeQuery request, CancellationToken ct)
        {
           var ordersFromTargetRange = await _orderRepository.GetOrderByDateRangeAsync(request.FromDate, request.ToDate, ct);

           var result = ordersFromTargetRange.Select( x => new GetAllMiseOnPlaceOrdersByDateRangeDto(
               x.CustomerId,
               x.DiscountCode,
               x.DiscountPrice,
               x.Price,
               x.Payable,
               x.Payment
               )).ToList();

            return result;
        }
    }
}
