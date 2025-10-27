using MakFood.Kitchen.Domain.Base;
using MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;

namespace MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate
{
    public abstract class Payment : BaseEntity<Guid>
    {
        protected Payment(decimal totalAmount, decimal reminingAmount, PaymentMathods ownerPaymentMethod,
            decimal ownerAmount, decimal ownerPaidAmount)
        {
            TotalAmount = totalAmount;
            ReminingAmount = reminingAmount;
            OwnerPaymentMethod = ownerPaymentMethod;
            OwnerAmount = ownerAmount;
            OwnerPaidAmount = ownerPaidAmount;
        }

        public decimal TotalAmount { get; protected set; }
        public decimal ReminingAmount { get; protected set; }
        public PaymentMathods OwnerPaymentMethod { get; protected set; }
        public decimal OwnerAmount { get; protected set; }
        public decimal OwnerPaidAmount { get; protected set; }
        

    }
}
