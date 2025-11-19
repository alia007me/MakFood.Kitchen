using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;



namespace MakFood.Kitchen.Infrastructure.Repositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<bool> IsExistByIdAsync(Guid productId)
        {
            return await _context.Products
                .AnyAsync(x => x.Id == productId);
        }

        public async Task<bool> IsExistByIdNameThumbnailPathAsync(Guid productId, string productName, string productThumbnailPath)
        {
            return await _context.Products
                .AnyAsync(x =>
                    x.Id == productId &&
                    x.Name == productName &&
                    x.ThumbnailPath == productThumbnailPath);
        }

        public async Task<bool> IsExistByIdNamePriceAsync(Guid productId, string productName, decimal price)
        {
            return await _context.Products
                .AnyAsync(x =>
                    x.Id == productId &&
                    x.Name == productName &&
                    x.Price == price);
        }

        public async Task<IEnumerable<GetFilteredProductsReadModel>> FilterAsync(string? name, Guid? categoryId, Guid? subcategoryId, CancellationToken ct)
        {
            var query = _context.Products.AsNoTracking().AsQueryable();

            // فیلتر بر اساس نام غذا
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.Contains(name));

            // فیلتر بر اساس زیر دسته
            if (subcategoryId.HasValue)
                query = query.Where(p => p.SubCategoryId == subcategoryId.Value);

            // فیلتر بر اساس دسته‌بندی
            if (categoryId.HasValue)
            {
                var subcategoryIds = await _context.Categories
                    .Where(c => c.Id == categoryId.Value)
                    .SelectMany(c => c.Subcategories)
                    .Select(sc => sc.Id)
                    .ToListAsync(ct);

                query = query.Where(p => subcategoryIds.Contains(p.SubCategoryId));
            }


            return await query.Select(x => new GetFilteredProductsReadModel
            {
                ProductId = x.Id,
                ProductName = x.Name,
                Price = x.Price,
                SubCategoryName = x.SubCategoryName

            }).ToListAsync(ct);

        }
        public async Task<Product> GetProduct(Guid prodactId, CancellationToken ct, bool needToTrack = true)
        {
            var Products = _context.Products.AsQueryable();
            Products = needToTrack ? Products : Products.AsNoTracking();
            var Product = await Products.SingleOrDefaultAsync(x => x.Id == prodactId);
            return Product!;
        }
    }
}