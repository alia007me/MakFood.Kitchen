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

        public Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProduct(Guid prodactId, CancellationToken ct, bool needToTrack = true)
        {
            var Products = _context.Products.AsQueryable();
            Products = needToTrack ? Products : Products.AsNoTracking();
            var Product = await Products.SingleOrDefaultAsync(x => x.Id == prodactId);
            return Product;
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
