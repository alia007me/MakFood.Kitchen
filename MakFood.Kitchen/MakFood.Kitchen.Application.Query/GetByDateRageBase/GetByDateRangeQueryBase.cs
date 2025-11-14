using MediatR;
using MediatR.Pipeline;

namespace MakFood.Kitchen.Application.Query.GetByDateRageBase
{
    public class GetByDateRangeQueryBase 
    {
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
    }
}
