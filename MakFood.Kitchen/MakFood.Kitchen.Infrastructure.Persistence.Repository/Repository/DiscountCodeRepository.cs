using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.DiscountPolicyAggrigate;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository
{
    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly ApplicationDbContext _context;
        public DiscountCodeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Discount> GetDiscountTracked(Guid id)
        {
            return await _context.Discounts.Include(D => D.DiscountPolicy).SingleOrDefaultAsync(d => d.Id == id);
        }
        public async Task<Discount> GetDiscount(Guid id)
        {
            return await _context.Discounts.Include(D => D.DiscountPolicy).AsNoTracking().SingleOrDefaultAsync(d => d.Id == id);
        }
        public async Task<Discount> GetDiscountByTitleTracked(string title)
        {
            return await _context.Discounts.Include(D => D.DiscountPolicy).SingleOrDefaultAsync(d => d.Title == title);
        }
    }
}