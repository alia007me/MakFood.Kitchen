using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, RemoveCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;



        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<RemoveCategoryCommandResponse> Handle(RemoveCategoryCommand request, CancellationToken ct)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.Id, ct);

            EnsureCategoryExists(category, request.Id);

            bool hasProducts = await _productRepository.HasProductsInCategoryAsync(category!.Id, ct);

            category.CheckCanBeRemoved(hasProducts);

            _categoryRepository.RemoveCategory(category);

            await _unitOfWork.Commit(ct);

            return new RemoveCategoryCommandResponse()
            {
                Id = category.Id,
            };
        }
        private void EnsureCategoryExists(Category? category, Guid categoryId)
        {
            if (category is null)
                throw new CategoryNotFoundException(categoryId);

        }
    }
}
