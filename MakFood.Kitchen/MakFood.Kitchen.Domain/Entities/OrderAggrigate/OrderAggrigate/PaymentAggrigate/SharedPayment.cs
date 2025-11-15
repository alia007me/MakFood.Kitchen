using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate
{
    public class SharedPayment : Payment
    {
        private SharedPayment() { }//ef
        public SharedPayment(decimal totalAmount, decimal reminingAmount,
            PaymentMathods ownerPaymentMethod, decimal ownerPaidAmount, Guid partnerId, decimal partnerPaidAmount,
            PaymentMathods partnerPaymentMethod, bool partnerApproved)
            : base(totalAmount, reminingAmount, ownerPaymentMethod)
        {
            TotalAmount = totalAmount;
            ReminingAmount = reminingAmount;
            OwnerPaymentMethod = ownerPaymentMethod;
            OwnerAmount = calculatePersonAmount(reminingAmount);
            OwnerPaidAmount = Decimal.Zero;
            PartnerAmount = calculatePersonAmount(reminingAmount);
            PartnerId = partnerId;
            PartnerPaidAmount = Decimal.Zero;
            PartnerPaymentMethod = partnerPaymentMethod;
            PartnerApproved = partnerApproved;
            paymentType = PaymentType.shared;
        }

        public decimal PartnerAmount { get; private set; }
        public Guid PartnerId { get; private set; }
        public decimal PartnerPaidAmount { get; private set; }
        public PaymentMathods PartnerPaymentMethod { get; private set; }
        public bool PartnerApproved { get; private set; }

        private decimal calculatePersonAmount(decimal reminingAmount)
        {
            return reminingAmount / 2;
        }
    }
}
