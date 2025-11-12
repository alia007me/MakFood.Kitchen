using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Enum;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;

namespace MakFood.Kitchen.Domain.Entities.DiscountAggrigate.DiscountPolicyAggrigate
{
    public class AllPermittedPolicy : DiscountPolicy
    {
        private readonly List<Guid> _used;
        public AllPermittedPolicy() : base(DiscountPolicyType.AllPermitted)
        {
            _used = new List<Guid>();
        }


        public override bool IsPermitted(Guid CamtomerId)
        {
            CustomeridValidator(CamtomerId);
            return (!_used.Contains(CamtomerId)); // return false if guid was in list and true if it wasent
        }
        public override void UseDiscount(Guid CastomerId)
        {
            CustomeridValidator(CastomerId);
            _used.Add(CastomerId);
        }
        private void CustomeridValidator(Guid customerId)
        {
            customerId.CheckNullOrEmpty("Customer Id");
        }
    }
}

