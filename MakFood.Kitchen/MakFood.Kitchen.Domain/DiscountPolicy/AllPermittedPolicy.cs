using MakFood.Kitchen.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.DiscountPolicy
{
    public class AllPermittedPolicy :  DiscountPolicy 
    {
        public AllPermittedPolicy() 
        {
            Type = DiscountPolicyType.AllPermitted;
        }
        public override bool IsPermitted(Guid CamtomerId)=>true;
    }
}

