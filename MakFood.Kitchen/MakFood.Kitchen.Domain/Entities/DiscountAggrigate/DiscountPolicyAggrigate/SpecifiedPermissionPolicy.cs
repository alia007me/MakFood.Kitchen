using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Enum;

namespace MakFood.Kitchen.Domain.Entities.DiscountAggrigate.DiscountPolicyAggrigate
{
    public class SpecifiedPermisionPolicy : DiscountPolicy
    {
        private SpecifiedPermisionPolicy() { }//ef
        private List<Guid> _customers = new List<Guid>();
        public SpecifiedPermisionPolicy(IEnumerable<Guid> customerIds) : base(DiscountPolicyType.SpecifiedPermision)
        {

            _customers = customerIds.ToList() ?? new List<Guid>();
        }

        public IEnumerable<Guid> Customers => _customers.AsReadOnly();
        
        #region Behavior
        public override bool IsPermitted(Guid customerId)
        {
            return Customers.Contains(customerId);
        }

        public void AddCustomers(Guid customerId)
        {
            _customers.Add(customerId);
        }
        #endregion

        



    }
}