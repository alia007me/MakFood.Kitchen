using MakFood.Kitchen.Domain.Entities.CartAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public async Task<Product> GetProductTracked(Guid prodactId, CancellationToken ct)
        {
            var Product = await _applicationDbContext.Products.SingleOrDefaultAsync(x => x.Id == prodactId);
            return Product;
        }
        public async Task<Product> GetProduct(Guid prodactId, CancellationToken ct)
        {
            var Product = await _applicationDbContext.Products.AsNoTracking().SingleOrDefaultAsync(x => x.Id == prodactId);
            return Product;
        }
    }
}

