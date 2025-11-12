using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate
{
    public class Order : BaseEntity<Guid>
    {
        private List<OrderState> _stateHistory = new List<OrderState>();
        private List<Constituent> _constituents = new List<Constituent>();

        public Order(Guid customerId, Discount discountCode, Payment payment, List<Constituent> constituents)
        {
            Id = Guid.NewGuid();

            CustomerId = customerId;
            DiscountCode = discountCode;
            Price = CalculatePrice();
            DiscountPrice = CalculateDiscountPrice(DiscountCode, Price);
            Payable = CalculatePayable(Price, DiscountPrice);
            Payment = payment;
            _stateHistory.Add(CurrentState.Created());

        }
        public Order(Guid customerId, Payment payment, List<Constituent> constituents)
        {
            Id = Guid.NewGuid();

            CustomerId = customerId;
            DiscountCode = null;
            Price = CalculatePrice();
            DiscountPrice = decimal.Zero;
            Payable = Price;
            Payment = payment;
            _stateHistory.Add(CurrentState.Created());

        }
        private Order() //ef
        {
            
        }

        public Guid CustomerId { get;private set; }
        public Discount? DiscountCode { get;private set; }
        public OrderState CurrentState => _stateHistory.OrderByDescending(c => c.CreationDateTime).First();
        public decimal DiscountPrice { get;private set; }
        public decimal Price { get;private set; }
        public decimal Payable { get;private set; }
        public IEnumerable<Constituent> Consistencies => _constituents.AsEnumerable();
        public Payment Payment { get; private set; }


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

        #region Validators

        private void CheckConstituentsList(List<Constituent> constituents)
        {
            constituents.CheckNullOrEmpty("constituents List");
        }

        #endregion

        #region CalculatePrice

        private decimal CalculatePrice()
        {
            decimal total = decimal.Zero;
            foreach (var constituent in _constituents)
            {
                total += constituent.Price;
            }

            return total;
        }

        private decimal CalculateDiscountPrice(Discount discount, decimal price)
        {
            var discountAmount = ((discount.Percent / 100) * price);
            discountAmount = Math.Round(discountAmount, 2);
            DiscountPrice = discountAmount;
            return discountAmount;

        }

        private decimal CalculatePayable(decimal total, decimal discountAmount)
        {
            return total - discountAmount;
        }

        #endregion
    }
}
