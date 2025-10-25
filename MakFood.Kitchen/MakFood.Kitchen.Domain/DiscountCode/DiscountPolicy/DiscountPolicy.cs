using MakFood.Kitchen.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.DiscoudCode.DiscountPolicy
{
    public abstract class DiscountPolicy : BaseEntity<Guid>
    {
        public DiscountPolicyType Type { get; private set; }
        #region behavior
        public abstract bool IsPermitted(Guid CamtomerId);
        #endregion
      
        
    }
}
