using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate
{
    public class SharedPayment : Payment
    {

        private SharedPayment() { }//ef
        public SharedPayment(decimal totalAmount, PaymentMathods ownerPaymentMethod,
            Guid partnerId)
            : base(totalAmount, ownerPaymentMethod)
        {
            TotalAmount = totalAmount;
            ReminingAmount = totalAmount;
            OwnerPaymentMethod = ownerPaymentMethod;
            OwnerAmount = calculatePersonAmount(totalAmount);
            OwnerPaidAmount = Decimal.Zero;

            PartnerId = partnerId;
            PartnerAmount = calculatePersonAmount(totalAmount);
            PartnerPaidAmount = Decimal.Zero;
            PartnerPaymentMethod = null;
            PartnerApproved = null;

            PaymentType = PaymentType.Shared;
        }

        public decimal PartnerAmount { get; private set; }
        public Guid PartnerId { get; private set; }
        public decimal PartnerPaidAmount { get; private set; }
        public PaymentMathods? PartnerPaymentMethod { get; private set; }
        public bool? PartnerApproved { get; private set; }


        #region Behaviors
        private decimal calculatePersonAmount(decimal reminingAmount)
        {
            return reminingAmount / 2;
        }

        public void SetPartnerPaymentMethod(PaymentMathods partnerPaymentMethod)
        {
            Check(new PaymentMethodShouldNotBeSelectedMoreThanOnceBR(PartnerPaymentMethod));
            PartnerPaymentMethod = partnerPaymentMethod;
        }

        public void UpdatePartnerPaymentMethod(PaymentMathods partnerPaymentMethod)
        {
            Check(new PaymentMethodMustBeSetBeforeUpdateBR(PartnerPaymentMethod));
            Check(new PaymentMethodMustNotBeChangedAfterPaymentStartedBR(PartnerPaidAmount));
            PartnerPaymentMethod = partnerPaymentMethod;
        }

        public void RegisterPartnerPaymentAmount(decimal amount)
        {
            Check(new PayAmountMustBePositiveBR(amount));
            Check(new PaymentAmountMustNotExceedRemainingAmountBR(PartnerAmount, PartnerPaidAmount, amount));
            PartnerPaidAmount += amount;
        }
        #endregion
    }
}
