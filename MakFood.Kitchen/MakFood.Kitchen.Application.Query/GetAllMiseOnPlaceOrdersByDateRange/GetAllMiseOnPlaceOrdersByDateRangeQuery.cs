using MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrdersByDateRange;
using MakFood.Kitchen.Application.Query.GetByDateRageBase;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrderByDateRange
{
    public class GetAllMiseOnPlaceOrdersByDateRangeQuery : GetByDateRangeQueryBase,IRequest<GetAllMiseOnPlaceOrdersByDateRangeResponse>
    {
    }
}
