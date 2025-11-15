using FluentValidation;
using MakFood.Kitchen.Application.Query.GetByDateRageBase;
using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetFoodRequestsByDateRange
{
    public record GetFoodRequestsByDateDto(Guid ProductId,
                                           string ProductName,
                                           long Count
        );

    public class GetFoodRequestsByDateQuery : GetByDateRangeQueryBase, IRequest<List<GetFoodRequestsByDateDto>>
    {
    }

    public class GetFoodRequestsByDateValidation : AbstractValidator<GetFoodRequestsByDateQuery>
    {
        public GetFoodRequestsByDateValidation()
        {
            Include(new GetByDateRangeValidationBase());
        }
    }

    public class GetFoodRequestsByDateHandler : IRequestHandler<GetFoodRequestsByDateQuery, List<GetFoodRequestsByDateDto>>
    {
        private readonly IFoodRequestRepository _foodRequestRepository;

        public GetFoodRequestsByDateHandler(IFoodRequestRepository foodRequestRepository)
        {
            _foodRequestRepository = foodRequestRepository;
        }

        public async Task<List<GetFoodRequestsByDateDto>> Handle(GetFoodRequestsByDateQuery request, CancellationToken ct)
        {
            var foodRequestsByDate = await _foodRequestRepository.GetFoodRequestsByDateRangeAsync(request.FromDate, request.ToDate, ct);

            if (foodRequestsByDate == null || !foodRequestsByDate.Any())
                return new List<GetFoodRequestsByDateDto>();

            var result = foodRequestsByDate.GroupBy(x => x.ProductId)
                                           .Select(x => new GetFoodRequestsByDateDto
                                           (
                                               x.Key,
                                               x.First().ProductName,
                                               x.Count()

                                               )).OrderByDescending(x => x.Count)
                                               .ToList();

            return result;
        }
    }
}
