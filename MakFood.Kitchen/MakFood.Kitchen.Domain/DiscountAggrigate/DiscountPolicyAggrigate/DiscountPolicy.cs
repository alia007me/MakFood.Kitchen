using MakFood.Kitchen.Domain.Base;
using MakFood.Kitchen.Domain.DiscountCodeAggrigate.Enum;

namespace MakFood.Kitchen.Domain.DiscountCodeAggrigate.DiscountPolicyAggrigate
{
    public abstract class DiscountPolicy : BaseEntity<Guid>
    {
        public DiscountPolicyType Type { get; private set; }

        protected DiscountPolicy(DiscountPolicyType type)
        {
            Type = type;
        }

        #region behavior
        public abstract bool IsPermitted(Guid CamtomerId);
        #endregion
      
        
    }
}
