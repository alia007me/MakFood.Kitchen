using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class PayAmountMustBePositiveBR : IBaseBusinessRule
    {
        private readonly decimal amount;

        public PayAmountMustBePositiveBR(decimal amount)
        {
            this.amount = amount;
        }

        public bool Check()
        {
            if (amount < 0) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new PayAmountMustBePositiveException();
        }
    }
}
