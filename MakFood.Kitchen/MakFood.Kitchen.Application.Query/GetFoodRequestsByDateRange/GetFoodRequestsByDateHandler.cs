using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract;
using MediatR;
using System.Linq;

namespace MakFood.Kitchen.Application.Query.GetFoodRequestsByDateRange
{
    public class GetFoodRequestsByDateHandler : IRequestHandler<GetFoodRequestsByDateQuery, IEnumerable<GetFoodRequestsByDateDto>>
    {
        private readonly IFoodRequestRepository _foodRequestRepository;

        public GetFoodRequestsByDateHandler(IFoodRequestRepository foodRequestRepository)
        {
            _foodRequestRepository = foodRequestRepository;
        }

        public async Task<IEnumerable<GetFoodRequestsByDateDto>> Handle(GetFoodRequestsByDateQuery request, CancellationToken ct)
        {
            var foodRequestsByDate = await _foodRequestRepository.GetFoodRequestsFoodCountByDateRangeAsync(request.FromDate, request.ToDate, ct);

            if (foodRequestsByDate == null || !foodRequestsByDate.Any())
                return new List<GetFoodRequestsByDateDto>();

            var result = foodRequestsByDate.Select(c => new GetFoodRequestsByDateDto(c.ProductId, c.ProductName, c.RequestedCount));

            return result;
        }
        
    }
}
