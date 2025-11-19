using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate
{
    public class Order : BaseEntity<Guid>
    {
        private List<OrderState> _stateHistory = new List<OrderState>();
        private List<Constituent> _constituents = new List<Constituent>();



        //public Order(Guid customerId, Discount discountCode, Payment payment, List<Constituent> constituents)
        //{
        //    Id = Guid.NewGuid();

        //    CustomerId = customerId;
        //    DiscountCode = discountCode;
        //    _constituents = constituents;
        //    Price = CalculatePrice();
        //    DiscountPrice = CalculateDiscountPrice(DiscountCode, Price);
        //    Payable = CalculatePayable(Price, DiscountPrice);
        //    Payment = payment;
        //    _stateHistory.Add(new CreatedOrderState());

        //}
        public Order(Guid customerId, Discount? discountCode, SinglePayment singlepayment, List<Constituent> constituents)
        {
            Id = Guid.NewGuid();
            _constituents = constituents;
            CustomerId = customerId;
            DiscountCode = discountCode;
            Price = CalculatePrice();
            DiscountPrice = CalculateDiscountPrice(DiscountCode, Price);
            Payable = CalculatePayable(Price, DiscountPrice);
            Payment = singlepayment;
            _stateHistory.Add(new CreatedOrderState());

        }
        public Order(Guid customerId, Discount? discountCode, SharedPayment sharedpayment, List<Constituent> constituents)
        {
            Id = Guid.NewGuid();
            _constituents = constituents;
            CustomerId = customerId;
            DiscountCode = discountCode;
            Price = CalculatePrice();
            DiscountPrice = CalculateDiscountPrice(DiscountCode, Price);
            Payable = CalculatePayable(Price, DiscountPrice);
            Payment = sharedpayment;
            _stateHistory.Add(new CreatedOrderState());

        }
        private Order() //ef
        {

        }

        public Guid CustomerId { get; private set; }
        public Discount? DiscountCode { get; private set; }
        public OrderState CurrentState => _stateHistory.OrderByDescending(c => c.CreationDateTime).First();
        public IReadOnlyList<OrderState> StateHistory => _stateHistory.AsReadOnly();
        public decimal DiscountPrice { get; private set; }
        public decimal Price { get; private set; }
        public decimal Payable { get; private set; }
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

        #region CalculatePrice

        private decimal CalculatePrice()
        {
            decimal total = decimal.Zero;
            foreach (var constituent in _constituents) {
                total += constituent.Price * constituent.Quantity;
            }

            return total;
        }

        private decimal CalculateDiscountPrice(Discount? discount, decimal price)
        {
            if (discount is null) return decimal.Zero;
            else if (price < discount.MinimumBalance) {
                throw new OrderTooCheapForDiscountCodeException();
            }
            else if (price > discount.MaximumBalance) {
                return discount.MaximumBalance * discount.Percent / 100;
            }
            else {
                return (price * (discount.Percent / 100));
            }
        }

        private decimal CalculatePayable(decimal total, decimal discountAmount)
        {
            return total - discountAmount;
        }

        #endregion 
    }
}
