using MakFood.Kitchen.Domain.SharedKarnel;
using MakFood.Kitchen.Domain.BussinesRules.Exceptions;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class DiscountExpiryDateMustBeInFutureBR : IBaseBusinessRule
    {
        private readonly DateOnly _expiryDate;

        public DiscountExpiryDateMustBeInFutureBR(DateOnly expiryDate)
        {
            _expiryDate = expiryDate;
        }

        public bool Check()
        {
            if (_expiryDate <= DateOnly.FromDateTime(DateTime.Now)) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new DiscountExpiryDateMustBeInFutureException();
        }
    }
}
