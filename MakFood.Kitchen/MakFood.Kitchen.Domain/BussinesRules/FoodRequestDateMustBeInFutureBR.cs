using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class FoodRequestDateMustBeInFutureBR : IBaseBusinessRule
    {
        private readonly DateOnly _targetDate;
        public FoodRequestDateMustBeInFutureBR(DateOnly input)
        {
            _targetDate = input;
        }

        public bool Check()
        {
            if (_targetDate <= DateOnly.FromDateTime(DateTime.Now)) return false;

            return true;

        }

        public Exception Throws()
        {
            throw new FoodRequestDateMustBeInFutureException();
        }
    }
}
