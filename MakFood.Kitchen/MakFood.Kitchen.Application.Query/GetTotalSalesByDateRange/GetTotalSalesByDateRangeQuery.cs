using MakFood.Kitchen.Application.Query.GetByDateRageBase;
using MediatR;


namespace MakFood.Kitchen.Application.Query.GetTotalSalesByDateRange
{
    public class GetTotalSalesByDateRangeQuery : GetByDateRangeQueryBase,IRequest<GetTotalSalesByDateRangeDto>
    {
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
    }

}
