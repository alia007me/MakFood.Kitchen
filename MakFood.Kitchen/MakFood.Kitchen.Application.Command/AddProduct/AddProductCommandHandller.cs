using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.UnitOfWorks;
using MediatR;
namespace MakFood.Kitchen.Application.Command.AddProduct
{
    public class AddProductCommandHandller : IRequestHandler<AddProductCommand, AddProductCommandResponse>
    {
        public readonly IProductRepository _productRepository;
        public readonly ICategoriesRepository _categoriesRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandller(IProductRepository productRepository, ICategoriesRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._categoriesRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            CheckProductsToExistAccordingToName(request.Name, cancellationToken);
            var SubCategories = await _categoriesRepository.GetSubCategoryByIdAsync(request.SubCategoryId, cancellationToken);
            CheckForSubCategoryToExist(request.SubCategoryId, cancellationToken);
            var product = new Product
            (
                request.Name,
                request.Price,
                request.Description,
                request.ThumbnailPath,
                SubCategories,
                request.AvailableQuantity
            );

            _productRepository.AddProduct(product);
            await _unitOfWork.Commit(cancellationToken);
            return new AddProductCommandResponse(product.Id);
        }
        /// <summary>
        /// چک میکنه پروداکت وجود داره یا نه بر حسب اسم پروداکت
        /// </summary>
        /// <param name="name">اسم پروداکت</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="Exception">متن اکسپشن</exception>
        private void CheckProductsToExistAccordingToName(string name,CancellationToken cancellationToken)
        {
            var productIsNull =  _productRepository.GetByNameAsync(name, cancellationToken);
            if (productIsNull != null)
            {
                throw new Exception("this product has already been added");
            }
        }
       /// <summary>
       /// چک میکنه ساب کتگوری وجود داره یا نه بر حسب ایدی ساب کتگوری
       /// </summary>
       /// <param name="SubCategoryId">ایدی ساب کتگوری</param>
       /// <param name="cancellationToken"></param>
       /// <exception cref="Exception">متن اکسپشن</exception>
        private void CheckForSubCategoryToExist(Guid SubCategoryId, CancellationToken cancellationToken)
        {
            var SubCategories =  _categoriesRepository.GetSubCategoryByIdAsync(SubCategoryId, cancellationToken);
            if (SubCategories == null)
            {
                throw new Exception("subcategory not found");
            }
        }

    }
}
