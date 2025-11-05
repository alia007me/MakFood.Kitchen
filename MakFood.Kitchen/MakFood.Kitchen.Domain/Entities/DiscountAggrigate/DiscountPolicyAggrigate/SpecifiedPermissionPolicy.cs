using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Enum;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;

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
            CustomeridValidator(customerId);
            return Customers.Contains(customerId);
        }

        public void AddCustomers(Guid customerId)
        {
            CustomeridValidator(customerId);
            _customers.Add(customerId);
        }
        #endregion

        #region Validations

        private void CustomeridValidator(Guid customerId)
        {
            customerId.CheckNullOrEmpty("Customer Id");
        }

        #endregion



    }
}