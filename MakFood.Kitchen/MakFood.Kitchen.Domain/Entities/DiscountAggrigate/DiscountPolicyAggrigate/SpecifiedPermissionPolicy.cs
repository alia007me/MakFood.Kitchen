using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Enum;

namespace MakFood.Kitchen.Domain.Entities.DiscountAggrigate.DiscountPolicyAggrigate
{
    public class SpecifiedPermisionPolicy : DiscountPolicy
    {
        private SpecifiedPermisionPolicy() { }//ef
        private List<Guid> _customers;
        private List<Guid> _used;
        public SpecifiedPermisionPolicy(IEnumerable<Guid> customerIds) : base(DiscountPolicyType.SpecifiedPermision)
        {

            if (customerIds != null) {
                _customers = customerIds.ToList();
            }
            else { 
                _customers = new List<Guid>(); 
            }
            _used = new List<Guid>();
        }

        public IEnumerable<Guid> Customers => _customers.AsReadOnly();
        
        #region Behavior
        public override bool IsPermitted(Guid customerId)
        {
            return Customers.Contains(customerId)&&CustomeridValidator(customerId);
        }

        public void AddCustomers(Guid customerId)
        {
            _customers.Add(customerId);
        }
        public override void UseDiscount(Guid CastomerId)
        {
            _used.Add(CastomerId);
        }
        #endregion

        #region Validations

        private bool CustomeridValidator(Guid customerId)
        {
            if (_used.Contains(customerId)) {
                return false;
            }
            return true;
        }

        #endregion



    }
}