using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState
{
    public sealed class CreatedOrderState : OrderState
    {
        public override OrderStatus Status => OrderStatus.Created;
        public override MiseOnPlaceOrderState MiseOnPlace()
        {
            return new MiseOnPlaceOrderState();
        }
        public override CancelledOrderState Cancelled()
        {
            return new CancelledOrderState();
        }


    }

}