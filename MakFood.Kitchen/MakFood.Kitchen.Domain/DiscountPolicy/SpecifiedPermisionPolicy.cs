using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.DiscountPolicy
{
    public class SpecifiedPermisionPolicy : DiscountPolicy
    {
        public IEnumerable<Guid> Customers { get; set; }
        public SpecifiedPermisionPolicy(IEnumerable<Guid> customers)
        {
            Customers = customers;
            Type = DiscountPolicyType.SpecifiedPermision;
        }
        public override bool IsPermitted(Guid CamtomerId)
        {
            return Customers.Contains(CamtomerId);
        }
    }
}
