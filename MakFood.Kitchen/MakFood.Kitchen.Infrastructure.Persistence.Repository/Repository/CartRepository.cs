using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CartRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public async Task<Cart> GetCartById(Guid Id, CancellationToken ct, bool needToTrack = true)
        {
            var cart = _applicationDbContext.Carts.Include(c => c.CartItems).AsQueryable();
            cart = needToTrack ? cart : cart.AsNoTracking();
            return await cart.SingleAsync(c => c.Id == Id);
        }
    }
}
