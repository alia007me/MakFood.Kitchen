using MakFood.Kitchen.Domain.DiscountCodeAggrigate.Enum;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;

namespace MakFood.Kitchen.Domain.DiscountCodeAggrigate.DiscountPolicyAggrigate
{
    public class SpecifiedPermisionPolicy : DiscountPolicy
    {
        public SpecifiedPermisionPolicy(IEnumerable<Guid> customerIds) : base(DiscountPolicyType.SpecifiedPermision)
        {
            
            Customers = customerIds.ToList() ?? new List<Guid>();
        }

        public IEnumerable<Guid> Customers { get;private set; }
        
        #region Behavior
        public override bool IsPermitted(Guid CamtomerId)
        {
            return Customers.Contains(CamtomerId);
        }
        #endregion

         
    }
}