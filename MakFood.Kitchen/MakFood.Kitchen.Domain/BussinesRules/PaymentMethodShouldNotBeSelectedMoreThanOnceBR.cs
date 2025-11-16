using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class PaymentMethodShouldNotBeSelectedMoreThanOnceBR : IBaseBusinessRule
    {
        private readonly PaymentMathods? _paymentMathods;

        public PaymentMethodShouldNotBeSelectedMoreThanOnceBR(PaymentMathods? paymentMathods)
        {
            _paymentMathods = paymentMathods;
        }

        public bool Check()
        {
            if(_paymentMathods.HasValue) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new PaymentMethodShouldNotBeSelectedMoreThanOnceException();
        }
    }
}
