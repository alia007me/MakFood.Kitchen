using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.UnitOfWorks;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateProduct
{

    public class UpdateProductCommandHandller : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRepository productRepository;
        private readonly ICategoriesRepository categoryRepository;

        public UpdateProductCommandHandller(IUnitOfWork unitOfWork, IProductRepository productRepository, ICategoriesRepository categoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var subCategoryName = await categoryRepository.GetSubCategoryByIdAsync(request.SubCategoryId, cancellationToken);
            var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new ArgumentException("product not found");
            }
            if (request.Name != null)
                product.UpdateProductName(request.Name);
            if (request.Description != null)
                product.UpdateDescription(request.Description);
            if (request.ThumbnailPath != null)
                product.UpdateThumbnailPath(product.ThumbnailPath);
            if (request.Price.ToString() != null)
                product.UpdatePrice(request.Price);
            if (request.SubCategoryName != null)
                product.UpdateSubcategory(subCategoryName);
            if (request.QuantityToIncrease.ToString()!=null)
                product.IncreaseAvailableQuantity(request.QuantityToIncrease);
            if (request.QuantityToDecrease.ToString() != null)
                product.DecreaseAvailableQuantity(request.QuantityToIncrease);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
