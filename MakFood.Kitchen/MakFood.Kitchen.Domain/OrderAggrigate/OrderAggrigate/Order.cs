using MakFood.Kitchen.Domain.Base;
using MakFood.Kitchen.Domain.DiscountCodeAggrigate;
using MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.OrederState;
using MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate;

namespace MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate
{
    public class Order : BaseEntity<Guid>
    {
        private List<OrderState> _stateHistory = new List<OrderState>();
        private List<Constituent> _consistencies = new List<Constituent>();

        public Order(Guid customerId, DiscountCode discountCode,Payment payment)
        {
            Id = Guid.NewGuid();

            CustomerId = customerId;
            DiscountCode = discountCode;
            TotalPriceBeforeDiscount = CalculateTotalPriceBeforeDiscount();
            DiscountPrice = CalculateDiscountPrice(DiscountCode, TotalPriceBeforeDiscount);
            FinalTotalPrice = CalculateTotalPriceByDiscount(TotalPriceBeforeDiscount, DiscountPrice);
            Payment = payment;

        }

        public Guid CustomerId { get; set; }
        public DiscountCode DiscountCode { get; set; }
        public OrderState CurrentState => _stateHistory.OrderByDescending(c => c.CreationDateTime).First();
        public decimal DiscountPrice { get; set; }
        public decimal TotalPriceBeforeDiscount { get; set; }
        public decimal FinalTotalPrice { get; set; }
        public IEnumerable<Constituent> Consistencies => _consistencies.AsEnumerable();
        public Payment Payment { get; private set; }

        #region Behaviors


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

        private decimal CalculateTotalPriceBeforeDiscount()
        {
            decimal total = 0;
            foreach (var constituent in _consistencies)
            {
                total += constituent.Price;
            }

            return total;
        }

        private decimal CalculateDiscountPrice(DiscountCode discount, decimal price)
        {
            var discountAmount = ((discount.DiscountPercentage / 100) * price);
            discountAmount = Math.Round(discountAmount, 2);
            DiscountPrice = discountAmount;
            return discountAmount;

        }

        private decimal CalculateTotalPriceByDiscount(decimal total, decimal discountAmount)
        {
            return total - discountAmount;
        }

        #region DiscountValidator

        #endregion
    }
}
