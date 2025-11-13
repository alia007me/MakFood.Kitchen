using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;

using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public SubcategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Subcategory?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Subcategories
                .SingleOrDefaultAsync(s => s.Id == id, ct);
        }

        public async Task<bool> CheckIsExistByNameAsync(string name, CancellationToken ct)
        {
            return await _context.Subcategories.AnyAsync(s => s.Name == name, ct);
        }

        public async Task<List<Subcategory>> GetAllAsync(CancellationToken ct)
        {
            return await _context.Subcategories.ToListAsync(ct);
        }

        public async Task AddAsync(Subcategory subcategory, CancellationToken ct)
        {
            await _context.Subcategories.AddAsync(subcategory, ct);
        }

        public void Update(Subcategory subcategory)
        {
            _context.Subcategories.Update(subcategory);
        }

        public void Remove(Subcategory subcategory)
        {
            _context.Subcategories.Remove(subcategory);
        }
    }
}
