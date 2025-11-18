using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repositores
{
    public class CategoriesRepository : ICategoriesRepository

    {
        private readonly ApplicationDbContext _context;

        public CategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Subcategory> GetSubCategoryByIdAsync(Guid subCategoryId, CancellationToken ct)
        {
            return await _context.Categories.Include(w => w.Subcategories).SelectMany(m => m.Subcategories).SingleOrDefaultAsync(w => w.Id ==subCategoryId,ct);
        }
    }
}
