using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate
{
    public class SharedPayment : Payment
    {

        private SharedPayment() { }//ef
        public SharedPayment(decimal totalAmount, PaymentMathod ownerPaymentMethod,
            Guid ownerId, Guid partnerId)
            : base(totalAmount, ownerPaymentMethod, ownerId)
        {
            TotalAmount = totalAmount;
            RemainingAmount = totalAmount;
            OwnerAmount = CalculatePersonAmount(totalAmount);

            PartnerId = partnerId;
            PartnerAmount = CalculatePersonAmount(totalAmount);
            PartnerPaidAmount = Decimal.Zero;
            PartnerPaymentMethod = null;
            PartnerApproved = null;

            PaymentType = PaymentType.Shared;
        }
        public PaymentStatus OwnerPaymentStatus { get; protected set; }
        public PaymentStatus PartnerPaymentStatus { get; protected set; }
        public decimal PartnerAmount { get; private set; }
        public Guid PartnerId { get; private set; }
        public decimal PartnerPaidAmount { get; private set; }
        public PaymentMathod? PartnerPaymentMethod { get; private set; }
        public bool? PartnerApproved { get; set; }


        #region Behaviors
        private decimal CalculatePersonAmount(decimal RemainingAmount)
        {
            return RemainingAmount / 2;
        }
        public decimal GetPaymentAmountById(Guid id)
        {
            if (id == OwnerId)
                return OwnerAmount;
            else if (id == PartnerId)
                return PartnerAmount;
            else throw new ThisIsNotYourOrderException();
        }
        public void AproveOrder(bool partnerApproved, PaymentMathod? paymentMathod)
        {
            this.PartnerPaymentMethod = paymentMathod;
            this.PartnerApproved = partnerApproved;
            if (!partnerApproved)
                this.Cancelled();
        }
        public void SetPartnerPaymentMethod(PaymentMathod partnerPaymentMethod)
        {
            Check(new PaymentMethodShouldNotBeSelectedMoreThanOnceBR(PartnerPaymentMethod));
            PartnerPaymentMethod = partnerPaymentMethod;
        }

        public void UpdatePartnerPaymentMethod(PaymentMathod partnerPaymentMethod)
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
        #region overRides
        public override bool NeedToPay(Guid customerId)
        {
            return (this.PartnerId == customerId || this.OwnerId == customerId) ? true : false;
        }
        public override void Paid()
        {
            if (OwnerPaymentStatus == Enum.PaymentStatus.Paid && PartnerPaymentStatus == Enum.PaymentStatus.Paid)
                base.Paid();
        }
        public override void Pay(Guid id)
        {
            if (id == this.OwnerId) {
                if (OwnerPaymentStatus == Enum.PaymentStatus.Paid)
                    throw new YouPaidThisOrderException();
                OwnerPaidAmount = OwnerAmount;
                OwnerPaymentStatus = Enum.PaymentStatus.Paid;
                OwnerPaidTime = DateTime.Now;
            }
            else if (id == this.PartnerId) {
                if (PartnerPaymentStatus == Enum.PaymentStatus.Paid)
                    throw new YouPaidThisOrderException();
                PartnerPaidAmount = PartnerAmount;
                PartnerPaymentStatus = Enum.PaymentStatus.Paid;
            }
            else {
                throw new ThisIsNotYourOrderException();
            }
        }
        #endregion
    }
}
