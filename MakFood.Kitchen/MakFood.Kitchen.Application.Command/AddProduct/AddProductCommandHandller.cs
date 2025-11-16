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

namespace MakFood.Kitchen.Application.Command.AddProduct
{
    internal class AddProductCommandHandller : IRequestHandler<AddProductCommand, AddProductCommandResponce>
    {
        public readonly ApplicationDbContext _context;
        public readonly IProductRepository productRepository;
        public readonly ISubCategoryRepository subCategoryRepository;
        public readonly IUnitOfWork unitOfWork;

        public AddProductCommandHandller(ApplicationDbContext context, IProductRepository productRepository, ISubCategoryRepository subCategoryRepository, IUnitOfWork unitOfWork)
        {
            _context = context;
            this.productRepository = productRepository;
            this.subCategoryRepository = subCategoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<AddProductCommandResponce> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
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
            return new AddProductCommandResponce(product.Id);
        }
    }
}
