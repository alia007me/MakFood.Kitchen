using FluentValidation;
using MakFood.Kitchen.Application.Query.GetByDateRageBase;

namespace MakFood.Kitchen.Application.Query.GetFoodRequestsByDateRange
{
    public class GetFoodRequestsByDateValidation : AbstractValidator<GetFoodRequestsByDateQuery>
    {
        public GetFoodRequestsByDateValidation()
        {
            Include(new GetByDateRangeValidationBase());
        }
    }
}
