using MakFood.Kitchen.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.DiscoudCode.DiscountPolicy
{
    public class AllPermittedPolicy :  DiscountPolicy 
    {
        public AllPermittedPolicy() 
        {
            var type = DiscountPolicyType.AllPermitted;
        }
        public override bool IsPermitted(Guid CamtomerId)=>true;
    }
}

