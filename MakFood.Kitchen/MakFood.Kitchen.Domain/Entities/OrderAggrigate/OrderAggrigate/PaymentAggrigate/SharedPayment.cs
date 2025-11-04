using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate
{
    internal class SharedPayment : Payment
    {
        private SharedPayment()
        {
            
        }
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

        public decimal PartnerAmount { get; private set; }
        public Guid PartnerId { get; private set; }
        public decimal PartnerPaidAmount { get; private set; }
        public PaymentMathods PartnerPaymentMethod { get; private set; }
        public bool PartnerApproved { get;private set; }

    }
}
