using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Enum;

namespace MakFood.Kitchen.Domain.Entities.DiscountAggrigate.DiscountPolicyAggrigate
{
    public abstract class DiscountPolicy : BaseEntity<Guid>
    {
        public DiscountPolicyType Type { get; private set; }
        protected DiscountPolicy() { }//ef

        protected DiscountPolicy(DiscountPolicyType type)
        {
            Type = type;
        }

        #region behavior
        public abstract bool IsPermitted(Guid CamtomerId);
        #endregion
      
        
    }
}
