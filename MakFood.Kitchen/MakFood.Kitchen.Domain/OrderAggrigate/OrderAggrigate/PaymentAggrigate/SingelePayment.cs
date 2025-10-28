using MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;

namespace MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate
{
    public class SingelePayment : Payment
    {
        public SingelePayment(decimal totalAmount, decimal reminingAmount, PaymentMathods ownerPaymentMethod, decimal ownerAmount,
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
