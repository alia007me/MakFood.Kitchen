using MakFood.Kitchen.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.DiscountPolicy
{
    public abstract class DiscountPolicy : BaseEntity<Guid>
    {
        public DiscountPolicyType Type { get; set; }
        public abstract bool IsPermitted (Guid CamtomerId);
    }
}
