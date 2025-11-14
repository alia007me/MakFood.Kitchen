using FluentValidation;
using MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrderByDateRange;
using MakFood.Kitchen.Application.Query.GetByDateRageBase;


namespace MakFood.Kitchen.Application.Query.GetTotalSalesByDateRange
{
    public class GetTotalSalesByDateRangeValidation : AbstractValidator<GetTotalSalesByDateRangeQuery>
    {
        public GetTotalSalesByDateRangeValidation()
        {
            Include(new GetByDateRangeValidationBase());
        }
    }


}
