using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly ApplicationDbContext _context;
        public DiscountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Discount?> GetDiscountTracked(Guid id)
        {
            return await _context.Discounts.Include(D => D.DiscountPolicy).SingleOrDefaultAsync(d => d.Id == id);
        }
        public async Task<Discount?> GetDiscount(Guid id)
        {
            return await _context.Discounts.Include(D => D.DiscountPolicy).AsNoTracking().SingleOrDefaultAsync(d => d.Id == id);
        }
        public async Task<Discount?> GetDiscountByTitleTracked(string? title)
        {
            return await _context.Discounts.Include(D => D.DiscountPolicy).SingleOrDefaultAsync(d => d.Title == title);
        }
    }
}