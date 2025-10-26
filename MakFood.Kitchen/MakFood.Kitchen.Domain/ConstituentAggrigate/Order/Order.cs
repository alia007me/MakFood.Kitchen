using MakFood.Kitchen.Domain.Base;
using MakFood.Kitchen.Domain.Constituent.Order.OrederState;
using MakFood.Kitchen.Domain.ConstituentAggrigate.Order.Payment;

namespace MakFood.Kitchen.Domain.Constituent.Order
{
    public class Order : BaseEntity<Guid>
    {
        private List<OrderState> _stateHistory = new List<OrderState>();
        private List<Constituent> _consistencies = new List<Constituent>();

        public Order(Guid customerId, string discountCode,decimal totalPrice)
        {
            CustomerId = customerId;
            DiscountCode = discountCode;
            TotalPrice = totalPrice;
        }

        public Guid CustomerId { get; set; }
        public string DiscountCode { get; set; }
        public OrderState CurrentState => _stateHistory.OrderByDescending(c => c.CreationDateTime).First();
        public decimal TotalPrice { get; set; }
        public IEnumerable<Constituent> Consistencies  =>_consistencies.AsEnumerable();

        #region
        public Payment SentForPayment()
        {

        }
        public Payment SentForPayment(string hi)
        {

        }
        #endregion
        #region State
        public void Created()
        {
            _stateHistory.Add(CurrentState.Created());
        }

        public void MiseOnPlace()
        {
            _stateHistory.Add(CurrentState.MiseOnPlace());
        }

        public void Cancelled()
        {
            _stateHistory.Add(CurrentState.Cancelled());
        }
        #endregion
    }
}
