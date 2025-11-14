using MakFood.Kitchen.Application.Query.GetByDateRageBase;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetProductOrderCountsByDateRange
{
    public class GetProductOrderCountsByDateRangeQuery : GetByDateRangeQueryBase, IRequest<List<GetProductOrderCountsByDateRangeDto>>
    {
    }

}
