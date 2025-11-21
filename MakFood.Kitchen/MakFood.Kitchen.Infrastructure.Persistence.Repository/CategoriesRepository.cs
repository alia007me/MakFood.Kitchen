using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _context.Set<Subcategory>().Remove(subcategory);
        }
        public async Task<Category?> GetCategoryBySubcategoryId(Guid subcategoryId, CancellationToken ct)
        {
            return await _context.Categories
                .Include(c => c.Subcategories)
                .FirstOrDefaultAsync(c => c.Subcategories.Any(sc => sc.Id == subcategoryId), ct);
        }



    }
}
