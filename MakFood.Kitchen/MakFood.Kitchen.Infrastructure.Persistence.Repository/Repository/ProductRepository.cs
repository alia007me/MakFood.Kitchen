using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

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
    }
}

