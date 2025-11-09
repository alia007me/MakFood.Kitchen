using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;

using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository
{
    public class CategoriesRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Categories
                 .Include(c => c.Subcategories)
                .SingleOrDefaultAsync(c => c.Id == id, ct);
        }
        public async Task<bool> ExistNameAsync(string name, CancellationToken ct)
        {
            return await _context.Categories.AnyAsync(c => c.Name == name, ct);
        }


        public async Task<List<Category>> GetAllAsync(CancellationToken ct)
        {
            return await _context.Categories
                .Include(c => c.Subcategories)
                .ToListAsync(ct);
        }

        public async Task AddAsync(Category category, CancellationToken ct)
        {
            await _context.Categories.AddAsync(category, ct);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }


        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }

    }
}
