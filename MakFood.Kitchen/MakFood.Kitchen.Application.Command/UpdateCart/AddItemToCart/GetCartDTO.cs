using MakFood.Kitchen.Domain.Entities.CartAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.UpdateCart.AddItemToCart
{ 
        public record GetCartDTO (IEnumerable<CartItem> Items);
}
