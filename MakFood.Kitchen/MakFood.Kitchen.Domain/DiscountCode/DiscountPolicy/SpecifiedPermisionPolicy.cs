using MakFood.Kitchen.Infrastructure.Substructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.DiscoudCode.DiscountPolicy
{
    public class SpecifiedPermisionPolicy : DiscountPolicy
    {
        public IEnumerable<Guid> Customers { get;private set; }
        public SpecifiedPermisionPolicy(IEnumerable<Guid> customers)
        {
            Customers = customers;
            var type = DiscountPolicyType.SpecifiedPermision;
        }
        #region Behavior
        public override bool IsPermitted(Guid CamtomerId)
        {
            return Customers.Contains(CamtomerId);
        }
        #endregion

        #region Validation
        /// <summary>
        /// چک کردن نال نبودن ایدی کاستومر های وروردی
        /// </summary>
        /// <param name="customers"></param>
        private void CustomersValidation(IEnumerable<Guid> customers)
        {
            customers.CheckNullOrEmpty("customers");
        }
        #endregion
    }
}