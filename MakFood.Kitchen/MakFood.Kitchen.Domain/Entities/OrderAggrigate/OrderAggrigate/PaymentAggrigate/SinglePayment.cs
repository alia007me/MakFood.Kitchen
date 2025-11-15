using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate
{
    public class SinglePayment : Payment
    {
        private SinglePayment() { } //ef
        public SinglePayment(decimal totalAmount, decimal reminingAmount, PaymentMathods ownerPaymentMethod) : base(totalAmount, reminingAmount, ownerPaymentMethod)
        {
            TotalAmount = totalAmount;
            ReminingAmount = reminingAmount;
            OwnerPaymentMethod = ownerPaymentMethod;
            OwnerAmount = reminingAmount;
            paymentType = PaymentType.singel;
        }
    }
}
