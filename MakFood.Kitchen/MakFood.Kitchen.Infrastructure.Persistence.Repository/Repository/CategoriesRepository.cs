using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository
{
    public class CategoriesRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid Id, CancellationToken ct)
        {
            return await _context.Categories
                 .Include(c => c.Subcategories)
                .SingleOrDefaultAsync(c => c.Id == Id, ct);
        }
        public async Task<bool> CheckCategoryIsExistByNameAsync(string name, CancellationToken ct)
        {
            return await _context.Categories.AnyAsync(c => c.Name == name, ct);
        }
        public async Task<Subcategory?> GetSubcategoryByIdAsync(Guid subcategoryId, CancellationToken ct)
        {
           return await _context.Subcategories
                .SingleOrDefaultAsync(s => s.Id == subcategoryId, ct);

        }
        public void Add(Category category)
        {
             _context.Categories.Add(category);
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }

    }
}
