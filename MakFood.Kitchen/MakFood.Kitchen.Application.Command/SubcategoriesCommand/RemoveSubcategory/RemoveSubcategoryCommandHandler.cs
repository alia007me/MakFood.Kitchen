using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;
using static MakFood.Kitchen.Application.Command.SubcategoriesCommand.RemoveSubcategory.RemoveSubcategoryCommandHandler;

namespace MakFood.Kitchen.Application.Command.SubcategoriesCommand.RemoveSubcategory
{
    public partial class RemoveSubcategoryCommandHandler : IRequestHandler<RemoveSubcategoryCommand, RemoveSubcategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public RemoveSubcategoryCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveSubcategoryCommandResponse> Handle(RemoveSubcategoryCommand request, CancellationToken ct)
        {
            var category = await _categoryRepository.GetCategoryBySubcategoryId(request.SubCategoryId, ct);
            var subcategory = await _categoryRepository.GetSubcategoryByIdAsync(request.SubCategoryId, ct);

            EnsureSubcategoryExists(subcategory, request.SubCategoryId);

            await CheckAndApplyRemovalRules(subcategory, ct);


            category!.RemoveSubcategory(request.SubCategoryId);
            _categoryRepository.RemoveSubcategory(subcategory);

            await _unitOfWork.Commit(ct);

            return new RemoveSubcategoryCommandResponse
            {
                Id = subcategory.Id
            };
        }

        private void EnsureSubcategoryExists(Subcategory? subcategory, Guid subcategoryId)
        {
            if (subcategory is null)
                throw new SubcategoryNotFoundException($"Subcategory with Id '{subcategoryId}' not found.");
        }

        private async Task CheckAndApplyRemovalRules(Subcategory subcategory, CancellationToken ct)
        {
            bool hasProducts = await _productRepository.HasProductsInSubcategoriesAsync(subcategory.Id, ct);
            subcategory.CheckCanBeRemoved(hasProducts);
        }
    }
}


