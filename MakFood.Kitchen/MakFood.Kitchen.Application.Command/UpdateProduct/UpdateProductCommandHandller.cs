using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.UnitOfWorks;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateProduct
{

    public class UpdateProductCommandHandller : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public UpdateProductCommandHandller(IUnitOfWork unitOfWork, IProductRepository productRepository, ICategoriesRepository categoryRepository)
        {
            this._unitOfWork = unitOfWork;
            this._productRepository = productRepository;
            this._categoriesRepository = categoryRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var subCategoryName = await _categoriesRepository.GetSubCategoryByIdAsync(request.SubCategoryId, cancellationToken);
            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
            CheckProductsToExistAccordingToId(request.ProductId, cancellationToken);
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
            await _unitOfWork.Commit(cancellationToken);
            return true;
        }
        /// <summary>
        /// چک میکنه پروداکت وجود داره یا نه بر حسب ایدی پروداکت
        /// </summary>
        /// <param name="productId">ایدی پروداکت</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="Exception">متن اکسپشن</exception>
        private void CheckProductsToExistAccordingToId(Guid productId, CancellationToken cancellationToken)
        {
            var productIsNull = _productRepository.GetByIdAsync(productId, cancellationToken);
            if (productIsNull == null)
            {
                throw new Exception("product not found");
            }
        }
    }
}
