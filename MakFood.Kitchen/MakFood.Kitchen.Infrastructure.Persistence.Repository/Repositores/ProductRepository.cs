using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
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
       
        public void AddProduct(Product product)
        {
              _context.Add(product);
        }
        
        public async Task<Product> GetByIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(w => w.Id == productId, cancellationToken);
        }

        public async Task<Product> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(w => w.Name == name, cancellationToken);
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
        /// <summary>
        /// متد وید برای حذف کردن پروداکت از دیتابیس
        /// </summary>
        /// <param name="product">کلاس پروداکت</param>
        public  void RemoveProduct(Product product)
        {
             _context.Remove(product);
        }

    }
}
