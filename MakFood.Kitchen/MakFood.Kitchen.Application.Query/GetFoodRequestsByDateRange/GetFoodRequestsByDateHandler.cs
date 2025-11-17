using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract;
using MediatR;
using System.Linq;

namespace MakFood.Kitchen.Application.Query.GetFoodRequestsByDateRange
{
    public class GetFoodRequestsByDateHandler : IRequestHandler<GetFoodRequestsByDateQuery, GetFoodRequestsByDateRangeResponse>
    {
        private readonly IFoodRequestRepository _foodRequestRepository;

        public GetFoodRequestsByDateHandler(IFoodRequestRepository foodRequestRepository)
        {
            _foodRequestRepository = foodRequestRepository;
        }

        public async Task<GetFoodRequestsByDateRangeResponse> Handle(GetFoodRequestsByDateQuery request, CancellationToken ct)
        {
            var foodRequestsByDate = await _foodRequestRepository.GetFoodRequestsFoodCountByDateRangeAsync(request.FromDate, request.ToDate, ct);

            var GetFoodRequestsByDateRange = foodRequestsByDate.Select(c => new GetFoodRequestsByDateDto(c.ProductId, c.ProductName, c.RequestedCount));

            var result = new GetFoodRequestsByDateRangeResponse(GetFoodRequestsByDateRange);

            return result;
        }
        
    }
}
