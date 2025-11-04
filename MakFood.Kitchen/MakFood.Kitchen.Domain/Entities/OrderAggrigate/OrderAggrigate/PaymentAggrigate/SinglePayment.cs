using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate
{
    public class SinglePayment : Payment
    {
        private SinglePayment()
        {
            
        }
        public SinglePayment(decimal totalAmount, decimal reminingAmount, PaymentMathods ownerPaymentMethod, decimal ownerAmount,
            decimal ownerPaidAmount) : base(totalAmount, reminingAmount, ownerPaymentMethod, ownerAmount, ownerPaidAmount)
        {
            TotalAmount = totalAmount;
            ReminingAmount = reminingAmount;
            OwnerPaymentMethod = ownerPaymentMethod;
            OwnerAmount = ownerAmount;
            OwnerPaidAmount = ownerPaidAmount;
        }
    }
}
