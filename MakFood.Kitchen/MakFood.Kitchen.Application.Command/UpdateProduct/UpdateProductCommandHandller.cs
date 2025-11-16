using MakFood.Kitchen.Application.Command.AddProduct;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using MakFood.Kitchen.Infrastructure.Persistence.Context.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.UpdateProduct
{

    public class UpdateProductCommandHandller : IRequestHandler<UpdateProductCommand, bool>
    {
        public readonly ApplicationDbContext _context;
        public readonly IProductRepository productRepository;
        public readonly ISubCategoryRepository subCategoryRepository;
        public readonly IUnitOfWork unitOfWork;

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var e = await productRepository.GetByIdAsync(request.ProductId);
            productRepository.RemoveProductAsync(e);
 
            var subCategory = await subCategoryRepository.GetSubCategoryBySabCategoryNameAsync(request.SubCategoryName);
            var product = new Product
                (
                    request.Name,
                    request.Price,
                    request.Description,
                    request.ThumbnailPath,
                    subCategory,
                    request.AvailableQuantity
                );
            await productRepository.AddProductAsync(product);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
