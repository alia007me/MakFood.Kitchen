using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct = default)
        {
            return await _context.Products.ToListAsync(ct);
        }

        public Task<bool> IsExistByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistByIdNamePriceAsync(Guid productId, string productName, decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistByIdNameThumbnailPathAsync(Guid productId, string productName, string productThumbnailPath)
        {
            throw new NotImplementedException();
        }
    }
}
