using MakFood.Kitchen.Domain.Base;

namespace MakFood.Kitchen.Domain.ConstituentAggrigate.Order.Payment
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

        public decimal TotalAmount { get; set; }
        public decimal ReminingAmount { get; set; }
        public PaymentMathods OwnerPaymentMethod{ get; set; }
        public decimal OwnerAmount { get; set; }
        public decimal OwnerPaidAmount { get; set; }
    }
}
