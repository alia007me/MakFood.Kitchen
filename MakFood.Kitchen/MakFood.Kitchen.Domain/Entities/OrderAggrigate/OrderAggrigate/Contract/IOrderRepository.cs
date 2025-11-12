using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract
{
    public interface IOrderRepository
    {
        public void AddOrder(Guid customerId, Discount discountCode, Payment payment, List<Constituent> constituents);
    }
}
