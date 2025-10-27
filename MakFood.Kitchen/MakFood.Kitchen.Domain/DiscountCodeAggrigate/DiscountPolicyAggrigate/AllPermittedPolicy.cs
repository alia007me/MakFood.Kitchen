using MakFood.Kitchen.Domain.DiscountCodeAggrigate.Enum;

namespace MakFood.Kitchen.Domain.DiscountCodeAggrigate.DiscountPolicyAggrigate
{
    public class AllPermittedPolicy :  DiscountPolicy 
    {
        public AllPermittedPolicy() : base(DiscountPolicyType.AllPermitted)
        {
        }

        public override bool IsPermitted(Guid CamtomerId)=>true;
    }
}

