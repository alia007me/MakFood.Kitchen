using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class PaymentMethodShouldNotBeSelectedMoreThanOnceBR : IBaseBusinessRule
    {
        private readonly PaymentMathod? _paymentMathod;

        public PaymentMethodShouldNotBeSelectedMoreThanOnceBR(PaymentMathod? paymentMathod)
        {
            _paymentMathod = paymentMathod;
        }

        public bool Check()
        {
            if (_paymentMathod.HasValue) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new PaymentMethodShouldNotBeSelectedMoreThanOnceException();
        }
    }
}
