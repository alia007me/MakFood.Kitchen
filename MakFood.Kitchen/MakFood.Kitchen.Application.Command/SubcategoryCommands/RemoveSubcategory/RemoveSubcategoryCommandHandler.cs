using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.RemoveSubcategory
{
    public class RemoveSubcategoryCommandHandler : IRequestHandler<RemoveSubcategoryCommand, RemoveSubcategoryCommandResponse>
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
            var subcategory = await _categoryRepository.GetSubcategoryByIdAsync(request.SubCategoryId, ct);

            EnsureSubcategoryExists(subcategory, request.SubCategoryId);

            await CheckAndApplyRemovalRules(subcategory!, ct);

            var category = await _categoryRepository.GetCategoryBySubcategoryId(request.SubCategoryId,ct);

            category!.RemoveSubcategory(request.SubCategoryId);

            await _unitOfWork.Commit(ct);

            return new RemoveSubcategoryCommandResponse
            {
                Id = subcategory!.Id
            };
        }

        private void EnsureSubcategoryExists(Subcategory? subcategory, Guid subcategoryId)
        {
            if (subcategory is null)
                throw new CategoryNotFoundException($"Subcategory with Id '{subcategoryId}' not found.");
        }

        private async Task CheckAndApplyRemovalRules(Subcategory subcategory, CancellationToken ct)
        {
            bool hasProducts = await _productRepository.HasProductsInSubcategoriesAsync(subcategory.Id, ct);
            subcategory.CheckCanBeRemoved(hasProducts);
        }
    }
}