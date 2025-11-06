using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class LimitBalanceMustBePositiveBR : IBaseBusinessRule
    {
        private readonly decimal _amount;

        public LimitBalanceMustBePositiveBR(decimal amount)
        {
            _amount = amount;
        }

        public bool Check()
        {
            if (_amount > 0) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new LimitBalanceMustBePositiveException();
        }
    }
}
