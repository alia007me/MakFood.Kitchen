using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository
{

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId, CancellationToken ct)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.Id == productId,ct);
        }

        public async Task<bool> IsExistByIdAsync(Guid productId, CancellationToken ct)
        {
            return await _context.Products
                .AsNoTracking()
                .AnyAsync(x => x.Id == productId, ct);
        }

        public async Task<bool> IsExistByIdNamePriceAsync(Guid productId, string productName, decimal price, CancellationToken ct)
        {
            return await _context.Products
                .AsNoTracking()
                .AnyAsync(x => x.Id == productId && x.Name == productName && x.Price == price, ct);
        }

        public async Task<bool> IsExistByIdNameThumbnailPathAsync(Guid productId, string productName, string productThumbnailPath, CancellationToken ct)
        {
            return await _context.Products
                .AsNoTracking()
                .AnyAsync(x => x.Id == productId && x.Name == productName && x.ThumbnailPath == productThumbnailPath, ct);
        }
    }
}
