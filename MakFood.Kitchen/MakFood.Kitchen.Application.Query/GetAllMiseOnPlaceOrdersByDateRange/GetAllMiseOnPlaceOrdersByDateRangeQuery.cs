using MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrderByDateRange;
using MakFood.Kitchen.Application.Query.GetByDateRageBase;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrderByDateRange
{
    public class GetAllMiseOnPlaceOrdersByDateRangeQuery : GetByDateRangeQueryBase,IRequest<IEnumerable<GetAllMiseOnPlaceOrdersByDateRangeDto>>
    {
    }
}
