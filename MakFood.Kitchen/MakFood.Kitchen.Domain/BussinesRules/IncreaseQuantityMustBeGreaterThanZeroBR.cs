using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class IncreaseQuantityMustBeGreaterThanZeroBR : IBaseBusinessRule
    {
        private readonly uint _quantity;

        public IncreaseQuantityMustBeGreaterThanZeroBR(uint quantity)
        {
            _quantity = quantity;
        }

        public bool Check()
        {
            if(_quantity > 0) return true;
            return false;
        }

        public Exception Throws()
        {
            throw new IncreaseQuantityMustBeGreaterThanZeroException();
        }
    }
}
