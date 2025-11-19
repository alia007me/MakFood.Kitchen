using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
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

        public async Task<Category?> GetCategoryByIdAsync(Guid Id, CancellationToken ct)
        {
            return await _context.Categories
                 .Include(c => c.Subcategories)
                .SingleOrDefaultAsync(c => c.Id == Id, ct);
        }
        public async Task<bool> IsCategoryNameExistAsync(string categoryName, CancellationToken ct)
        {
            return await _context.Categories
                .AnyAsync(c => c.Name == categoryName, ct);
        }
        public async Task<Subcategory?> GetSubcategoryByIdAsync(Guid subcategoryId, CancellationToken ct)
        {
           return await _context.Categories
                .SelectMany(c => c.Subcategories)
                .SingleOrDefaultAsync(s => s.Id == subcategoryId, ct);
        }
        public async Task<bool> IsSubcategoryNameExistAsync(Guid subcategoryId, string newName, CancellationToken ct)
        {
            var category = await _context.Categories
                .Include(c => c.Subcategories)
                .FirstOrDefaultAsync(c => c.Subcategories.Any(sc => sc.Id == subcategoryId), ct);

            if (category == null)
                return false;

            return category.Subcategories
                .Any(sc => sc.Name == newName && sc.Id != subcategoryId);
        }

        public void Add(Category category)
        {
             _context.Categories.Add(category);
        }

        public void RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public void RemoveSubcategory(Subcategory subcategory)
        {
            var category = _context.Categories
                .Include(c => c.Subcategories)
                .FirstOrDefault(c => c.Subcategories.Any(sc => sc.Id == subcategory.Id));

            if (category == null)
                throw new CategoryNotFoundException($"Category for Subcategory '{subcategory.Id}' not found.");

            category.RemoveSubcategory(subcategory.Id);

           
        }

    }
}
