using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly ApplicationDbContext _context;

        public DiscountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Discount discount)
        {
            _context.Add(discount);
        }

        public async Task<List<Discount>> GetDiscountAccordingToTitle(string Title, CancellationToken cancellationToken)
        {
            var Discounts = await _context.Discounts.Include(w=>w.DiscountPolicy).Where(w => w.Title == Title).ToListAsync(cancellationToken);
            return Discounts;
        }
    }
}
