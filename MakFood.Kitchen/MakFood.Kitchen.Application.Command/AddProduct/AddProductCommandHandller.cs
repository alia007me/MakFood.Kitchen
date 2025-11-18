using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using MakFood.Kitchen.Infrastructure.Persistence.Context.UnitOfWorks;
using MediatR;
namespace MakFood.Kitchen.Application.Command.AddProduct
{
    public class AddProductCommandHandller : IRequestHandler<AddProductCommand, AddProductCommandResponse>
    {
        public readonly IProductRepository productRepository;
        public readonly ICategoriesRepository categoryRepository;
        public readonly IUnitOfWork unitOfWork;

        public AddProductCommandHandller(IProductRepository productRepository, ICategoriesRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var productIsNull = productRepository.GetByNameAsync(request.Name, cancellationToken);
            if (productIsNull != null)
            {
                throw new Exception("this product has already been added");
            }
            var SubCategory = await categoryRepository.GetSubCategoryByIdAsync(request.SubCategoryId, cancellationToken);
            if (SubCategory != null)
            {
                throw new Exception("subcategory not found");
            }
            var product = new Product
            (
                request.Name,
                request.Price,
                request.Description,
                request.ThumbnailPath,
                SubCategory,
                request.AvailableQuantity
            );

            productRepository.AddProduct(product);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return new AddProductCommandResponse(product.Id);
        }
    }
}
