using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class PaymentMethodMustBeSetBeforeUpdateBR : IBaseBusinessRule
    {
        private readonly PaymentMathod? _paymentMathod;

        public PaymentMethodMustBeSetBeforeUpdateBR(PaymentMathod? paymentMathod)
        {
            _paymentMathod = paymentMathod;
        }

        public bool Check()
        {
            if (_paymentMathod.HasValue) return true;
            return false;
        }

        public Exception Throws()
        {
            throw new PaymentMethodMustBeSetBeforeUpdateException();
        }
    }
}
