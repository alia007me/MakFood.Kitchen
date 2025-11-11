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
        public async Task<Cart> GetCartById(Guid Id, CancellationToken ct)
        {
            var cart = await _applicationDbContext.Carts.AsNoTracking().Include(c => c.CartItems).SingleOrDefaultAsync(c => c.Id == Id);
            return cart;
        }
        public async Task<Cart> GetCartByIdTracked(Guid Id, CancellationToken ct)
        {
            var cart = await _applicationDbContext.Carts.Include(c => c.CartItems).SingleOrDefaultAsync(c => c.Id == Id);
            return cart;
        }
        public void AddNewCart(Guid id)
        {
            _applicationDbContext.Add(new Cart(id));
        }
    }
}
