using MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;

namespace MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate
{
    internal class SharedPayment : Payment
    {
        public SharedPayment(decimal totalAmount, decimal reminingAmount,
            PaymentMathods ownerPaymentMethod, decimal ownerAmount, decimal ownerPaidAmount,
            decimal partnerAmount, Guid partnerId, decimal partnerPaidAmount, PaymentMathods partnerPaymentMethod, bool partnerApproved)
            : base(totalAmount, reminingAmount, ownerPaymentMethod, ownerAmount, ownerPaidAmount)
        {
            TotalAmount = totalAmount;
            ReminingAmount = reminingAmount;
            OwnerPaymentMethod = ownerPaymentMethod;
            OwnerAmount = ownerAmount;
            OwnerPaidAmount = ownerPaidAmount;
            PartnerAmount = partnerAmount;
            PartnerId = partnerId;
            PartnerPaidAmount = partnerPaidAmount;
            PartnerPaymentMethod = partnerPaymentMethod;
            PartnerApproved = partnerApproved;
        }

        public decimal PartnerAmount { get; set; }
        public Guid PartnerId { get; set; }
        public decimal PartnerPaidAmount { get; set; }
        public PaymentMathods PartnerPaymentMethod { get; set; }
        public bool PartnerApproved { get; set; }

    }
}
