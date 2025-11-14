using FluentValidation;
using MakFood.Kitchen.Application.Query.GetByDateRageBase;

namespace MakFood.Kitchen.Application.Query.GetProductOrderCountsByDateRange
{
    public class GetProductOrderCountsByDateRangeValidation : AbstractValidator<GetProductOrderCountsByDateRangeQuery>
    {
        public GetProductOrderCountsByDateRangeValidation()
        {
            Include(new GetByDateRangeValidationBase());
        }
    }

}
