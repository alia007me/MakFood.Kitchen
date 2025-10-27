using MakFood.Kitchen.Domain.DiscountAggrigate.Enum;

namespace MakFood.Kitchen.Domain.DiscountAggrigate.DiscountPolicyAggrigate
{
    public class AllPermittedPolicy :  DiscountPolicy 
    {
        public AllPermittedPolicy() : base(DiscountPolicyType.AllPermitted)
        {
        }

        public override bool IsPermitted(Guid CamtomerId)=>true;
    }
}

