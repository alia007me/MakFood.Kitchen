using MakFood.Kitchen.Domain.SharedKarnel;
using MakFood.Kitchen.Domain.BussinesRules.Exceptions;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class DiscountPercentageMustBeBetweenZeroAndOnehundredBR : IBaseBusinessRule
    {
        private readonly decimal _percentage;

        public DiscountPercentageMustBeBetweenZeroAndOnehundredBR(decimal percentage)
        {
            _percentage = percentage;
        }

        public bool Check()
        {
            if (_percentage <= 0 || _percentage > 100) return false;
            return true;

        }

        public Exception Throws()
        {
            throw new DiscountPercentageMustBeBetweenZeroAndOnehundredException();
        }
    }
}
