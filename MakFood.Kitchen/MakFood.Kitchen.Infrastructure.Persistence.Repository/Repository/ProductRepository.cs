using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public async Task<Product> GetProduct(Guid prodactId, CancellationToken ct, bool needToTrack = true)
        {
            var Products = _applicationDbContext.Products.AsQueryable();
            Products = needToTrack ? Products : Products.AsNoTracking();
            var Product = await Products.SingleOrDefaultAsync(x => x.Id == prodactId);
            return Product;
        }

        public async Task<bool> HasProductsInSubcategoriesAsync(Guid subcategoryId, CancellationToken ct)
        {
            return await _applicationDbContext.Products
               .AnyAsync(p => p.SubCategoryId == subcategoryId, ct);
        }

        public async Task<bool> HasProductsInCategoryAsync(Guid categoryId, CancellationToken ct)
        {
            var subcategoryIds = await _applicationDbContext.Categories
                .Where(c => c.Id == categoryId)
                .SelectMany(c => c.Subcategories)
                .Select(sc => sc.Id)
                .ToListAsync(ct);

            return await _applicationDbContext.Products
                .AnyAsync(p => subcategoryIds.Contains(p.SubCategoryId), ct);
        }
    }
}

