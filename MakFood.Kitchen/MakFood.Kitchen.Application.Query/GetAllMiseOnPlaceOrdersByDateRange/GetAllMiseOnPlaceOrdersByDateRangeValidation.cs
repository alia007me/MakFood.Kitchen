using FluentValidation;
using MakFood.Kitchen.Application.Query.GetByDateRageBase;

namespace MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrderByDateRange
{
    public class GetAllMiseOnPlaceOrdersByDateRangeValidation : AbstractValidator<GetAllMiseOnPlaceOrdersByDateRangeQuery>
    {
        public GetAllMiseOnPlaceOrdersByDateRangeValidation()
        {
            Include(new GetByDateRangeValidationBase());
        }
    }
}
