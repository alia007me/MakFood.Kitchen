using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase
{
    public abstract class Payment : BaseEntity<Guid>
    {
        protected Payment() { } //ef
        protected List<PaymentState> _PaymentHistory = new List<PaymentState>();
        protected Payment(decimal totalAmount, PaymentMathod ownerPaymentMethod, Guid ownerId)
        {
            Id = Guid.NewGuid();

            TotalAmount = totalAmount;
            RemainingAmount = totalAmount;
            OwnerPaymentMethod = ownerPaymentMethod;
            OwnerId = ownerId;
            OwnerPaidAmount = Decimal.Zero;
            _PaymentHistory.Add(new CreatedPaymentState());
        }
        public Guid OwnerId { get; protected init; }
        public decimal TotalAmount { get; protected set; }
        public decimal RemainingAmount { get; protected set; }
        public PaymentMathod OwnerPaymentMethod { get; protected set; }
        public PaymentState PaymentStatus => _PaymentHistory.OrderByDescending(c => c.CreationDateTime).First();
        public PaymentType PaymentType { get; protected set; }
        public decimal OwnerAmount { get; protected set; }
        public decimal OwnerPaidAmount { get; protected set; }
        public DateTime? OwnerPaidTime { get; protected set; }
        public IEnumerable<PaymentState> PaymentLog => _PaymentHistory.AsEnumerable();

        #region Behaviors
        public void Cancelled()
        {
            _PaymentHistory.Add(new CancelledPaymentState());
        }
        public virtual void Paid()
        {
            _PaymentHistory.Add(new PaidPaymentState());
        }

        public void SetOwnerPaymentMethod(PaymentMathod ownerPaymentMethod)
        {
            Check(new PaymentMethodShouldNotBeSelectedMoreThanOnceBR(OwnerPaymentMethod));
            OwnerPaymentMethod = ownerPaymentMethod;
        }

        public void UpdateOwnerPaymentMethod(PaymentMathod ownerPaymentMethod)
        {
            Check(new PaymentMethodMustBeSetBeforeUpdateBR(OwnerPaymentMethod));
            Check(new PaymentMethodMustNotBeChangedAfterPaymentStartedBR(OwnerPaidAmount));
            OwnerPaymentMethod = ownerPaymentMethod;
        }

        public void RegisterOwnerPaymentAmount(decimal amount)
        {
            Check(new PayAmountMustBePositiveBR(amount));
            Check(new PaymentAmountMustNotExceedRemainingAmountBR(OwnerAmount, OwnerPaidAmount, amount));
            OwnerPaidAmount += amount;
        }
        #endregion
        #region abstractMethods
        public abstract bool NeedToPay(Guid id);
        public abstract void Pay(Guid id);
        #endregion
    }
}
