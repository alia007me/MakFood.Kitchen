using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MediatR;


namespace MakFood.Kitchen.Application.Query.GetTotalSalesByDateRange
{
    public class GetTotalSalesByDateRangeHandler : IRequestHandler<GetTotalSalesByDateRangeQuery, GetTotalSalesByDateRangeDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetTotalSalesByDateRangeHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetTotalSalesByDateRangeDto> Handle(GetTotalSalesByDateRangeQuery request, CancellationToken ct)
        {
            var miseOnPlaceOrdersFromDateRange = await _orderRepository.GetOrderByDateRangeAsync(request.FromDate, request.ToDate, ct);

            decimal result = miseOnPlaceOrdersFromDateRange.Sum(x => x.Payable);

            GetTotalSalesByDateRangeDto finalResult = new GetTotalSalesByDateRangeDto(result);
            

            return finalResult;
        }
    }

}
