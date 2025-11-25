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
            var result = await _orderRepository.GetTotalSalesByDate(request.FromDate, request.ToDate, ct);

            GetTotalSalesByDateRangeDto finalResult = new GetTotalSalesByDateRangeDto(result);
            

            return finalResult;
        }
    }

}
