using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repositores
{
    public class ProductRepository : IProductRepository
    {
        public readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
             await _context.AddAsync(product);
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
