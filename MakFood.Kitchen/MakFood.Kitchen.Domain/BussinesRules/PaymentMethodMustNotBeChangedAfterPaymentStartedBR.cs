using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class PaymentMethodMustNotBeChangedAfterPaymentStartedBR : IBaseBusinessRule
    {
        private readonly decimal _paidAmount;

        public PaymentMethodMustNotBeChangedAfterPaymentStartedBR(decimal paidAmount)
        {
            _paidAmount = paidAmount;
        }

        public bool Check()
        {
            if (_paidAmount != 0) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new PaymentMethodMustNotBeChangedAfterPaymentStartedException();
        }
    }
}
