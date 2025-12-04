using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Enum;

namespace MakFood.Kitchen.Domain.Entities.DiscountAggrigate.DiscountPolicyAggrigate
{
    public class AllPermittedPolicy : DiscountPolicy
    {
        private readonly List<Guid> _used;
        public AllPermittedPolicy() : base(DiscountPolicyType.AllPermitted)
        {
            _used = new List<Guid>();
        }


        public override bool IsPermitted(Guid CumtomerId)
        {
            CustomeridValidator(CumtomerId);
            return (!_used.Contains(CumtomerId)); // return false if guid was in list and true if it wasent
        }
        public override void UseDiscount(Guid CustomerId)
        {
            CustomeridValidator(CustomerId);
            _used.Add(CustomerId);
        }
        private void CustomeridValidator(Guid customerId)
        {
        }
    }
}

