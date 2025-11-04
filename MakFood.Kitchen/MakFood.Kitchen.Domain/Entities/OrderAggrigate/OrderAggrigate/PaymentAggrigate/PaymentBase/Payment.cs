using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase
{
    public abstract class Payment : BaseEntity<Guid>
    {
        private List<PaymentState> _PaymentHistory = new List<PaymentState>();
        protected Payment(decimal totalAmount, decimal reminingAmount, PaymentMathods ownerPaymentMethod,
            decimal ownerAmount, decimal ownerPaidAmount)
        {
            TotalAmount = totalAmount;
            ReminingAmount = reminingAmount;
            OwnerPaymentMethod = ownerPaymentMethod;
            OwnerAmount = ownerAmount;
            OwnerPaidAmount = ownerPaidAmount;
            _PaymentHistory.Add(new CreatedPaymentState());
        }
        protected Payment() //ef
        {
            
        }

        public decimal TotalAmount { get; protected set; }
        public PaymentState CurrentState => _PaymentHistory.OrderByDescending(c => c.CreationDateTime).First();
        public decimal ReminingAmount { get; protected set; }
        public PaymentMathods OwnerPaymentMethod { get; protected set; }
        public decimal OwnerAmount { get; protected set; }
        public decimal OwnerPaidAmount { get; protected set; }
        public IEnumerable<PaymentState> PaymentLog => _PaymentHistory.AsEnumerable();


        #region Behaviors
        private void Paid()
        {
            _PaymentHistory.Add(CurrentState.Paid());
        }
        
        private void Cancelled()
        {
            _PaymentHistory.Add(CurrentState.Cancelled());
        }
        #endregion

    }
}
