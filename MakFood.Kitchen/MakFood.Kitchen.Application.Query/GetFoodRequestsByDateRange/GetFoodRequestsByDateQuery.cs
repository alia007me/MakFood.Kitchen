using MakFood.Kitchen.Application.Query.GetByDateRageBase;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetFoodRequestsByDateRange
{
    public class GetFoodRequestsByDateQuery : GetByDateRangeQueryBase, IRequest<IEnumerable<GetFoodRequestsByDateDto>>
    {
    }
}
