using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.SubcategoriesCommand.CreateSubcategory
{
    public class CreateSubcategoryCommandHandler : IRequestHandler<CreateSubcategoryCommand, CreateSubcategorycommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSubcategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateSubcategorycommandResponse> Handle(CreateSubcategoryCommand request, CancellationToken ct)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId, ct);

            EnsureCategoryExists(category, request.CategoryId);

            ValidateSubcategoryNameIsUnique(category!, request.Name);

            var subcategory = new Subcategory(request.Name);

            category!.AddSubcategory(subcategory);

            await _unitOfWork.Commit(ct);

            return new CreateSubcategorycommandResponse
            {
                Id = subcategory.Id
            };
        }

        private void EnsureCategoryExists(Category? category, Guid categoryId)
        {
            if (category == null)
                throw new CategoryNotFoundException($"Category with Id '{categoryId}' not found.");
        }

        private void ValidateSubcategoryNameIsUnique(Category category, string subcategoryName)
        {
            if (category.Subcategories.Any(s => s.Name == subcategoryName))
                throw new IsAlreadyExistException($"Subcategory with name '{subcategoryName}' already exists.");
        }
    }
}
