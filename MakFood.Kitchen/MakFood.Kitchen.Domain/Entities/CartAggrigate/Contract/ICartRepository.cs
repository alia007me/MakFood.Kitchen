using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract
{
    public interface ICartRepository
    {
        public Task<Cart> GetCartById(Guid Id, CancellationToken ct, bool needToTrack = true);
        
    }
}
