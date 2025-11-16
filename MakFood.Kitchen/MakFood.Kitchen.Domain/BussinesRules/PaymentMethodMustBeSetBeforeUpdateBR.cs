using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class PaymentMethodMustBeSetBeforeUpdateBR : IBaseBusinessRule
    {
        private readonly PaymentMathods? _paymentMathods;

        public PaymentMethodMustBeSetBeforeUpdateBR(PaymentMathods? paymentMathods)
        {
            _paymentMathods = paymentMathods;
        }

        public bool Check()
        {
            if(_paymentMathods.HasValue) return true;
            return false;
        }

        public Exception Throws()
        {
            throw new PaymentMethodMustBeSetBeforeUpdateException();
        }
    }
}
