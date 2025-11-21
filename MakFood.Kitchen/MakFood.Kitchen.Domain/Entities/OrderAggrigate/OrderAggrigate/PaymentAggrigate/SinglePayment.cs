using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate
{
    public class SinglePayment : Payment
    {
        private SinglePayment() { } //ef
        public SinglePayment(decimal totalAmount, PaymentMathods ownerPaymentMethod, Guid ownerId) : base(totalAmount, ownerPaymentMethod, ownerId)
        {
            TotalAmount = totalAmount;
            ReminingAmount = totalAmount;
            OwnerPaymentMethod = ownerPaymentMethod;
            OwnerAmount = totalAmount;
            PaymentType = PaymentType.Single;
        }
        #region overRides
        public override bool NeedToPay(Guid customerId)
        {
            return (this.OwnerId == customerId) ? true : false;
        }
        public override void Pay(Guid id)
        {
            if (id == this.OwnerId) {
                OwnerPaidAmount = OwnerAmount;
                OwnerPaidTime = DateTime.Now;
                Paid();
            }
            else {
                throw new ThisIsNotYourOrderException();
            }

        }
        #endregion
    }
}
