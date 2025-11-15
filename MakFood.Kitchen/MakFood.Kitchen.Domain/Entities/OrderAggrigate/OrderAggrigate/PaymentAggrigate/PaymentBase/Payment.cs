using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State;
using System.Security.Principal;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase
{
    public abstract class Payment : BaseEntity<Guid>
    {
        protected Payment() { } //ef
        protected List<PaymentState> _PaymentHistory = new List<PaymentState>();
        protected Payment(decimal totalAmount, decimal reminingAmount, PaymentMathods ownerPaymentMethod)
        {
            TotalAmount = totalAmount;
            ReminingAmount = reminingAmount;
            OwnerPaymentMethod = ownerPaymentMethod;  
            OwnerPaidAmount = Decimal.Zero;
            _PaymentHistory.Add(new CreatedPaymentState());
        }
        public decimal TotalAmount { get; protected set; }
        public PaymentState CurrentState => _PaymentHistory.OrderByDescending(c => c.CreationDateTime).First();
        public decimal ReminingAmount { get; protected set; }
        public PaymentMathods OwnerPaymentMethod { get; protected set; }
        public PaymentStatus paymentStatus { get; protected set; }
        public PaymentType paymentType { get; protected set; }
        public decimal OwnerAmount { get; protected set; }
        public decimal OwnerPaidAmount { get; protected set; }
        public IEnumerable<PaymentState> PaymentLog => _PaymentHistory.AsEnumerable();

        #region Behaviors
        public void Cancelled()
        {
            _PaymentHistory.Add(CurrentState.Cancelled());
        }
        public void paied()
        {
            _PaymentHistory.Add(CurrentState.Paid());
        }


        public void ChangePaymentMethod(PaymentMathods OwnerPaymentMethod) 
        { 
            this.OwnerPaymentMethod = OwnerPaymentMethod;
        }
        #endregion

    }
}
