using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{

    public class TheMaximumBalanceMustBeGreaterThanTheMinimumBalanceBR : IBaseBusinessRule
    {
        private readonly decimal _minimumBalance;
        private readonly decimal _maximumBalance;

        public TheMaximumBalanceMustBeGreaterThanTheMinimumBalanceBR(decimal minimumBalance, decimal maximumBalance)
        {
            _minimumBalance = minimumBalance;
            _maximumBalance = maximumBalance;
        }

        public bool Check()
        {
            if (_minimumBalance > _maximumBalance) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new TheMaximumBalanceMustBeGreaterThanTheMinimumBalanceException();
        }
    }
}
