using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Enum;

namespace MakFood.Kitchen.Domain.Entities.DiscountAggrigate.DiscountPolicyAggrigate
{
    public class AllPermittedPolicy :  DiscountPolicy 
    {
        public AllPermittedPolicy() : base(DiscountPolicyType.AllPermitted)
        {
        }

        public override bool IsPermitted(Guid CamtomerId)=>true;
    }
}

