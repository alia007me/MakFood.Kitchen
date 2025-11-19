using MediatR;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate; // نیاز به ایمپورت نوع Category برای متد خصوصی

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken ct)
        {

            var category = await _categoryRepository.GetCategoryByIdAsync(request.Id, ct);

            EnsureCategoryExists(category, request.Id);

            await ValidateUniqueName(request.NewName, ct);

            category!.UpdateCategoryName(request.NewName);

            await _unitOfWork.Commit(ct);

            return new UpdateCategoryCommandResponse
            {
                Id = category.Id
            };
        }

        private void EnsureCategoryExists(Category? category, Guid categoryId)
        {
            if (category == null)
                throw new CategoryNotFoundException($"Category with Id '{categoryId}' not found.");
        }

        private async Task ValidateUniqueName(string newName, CancellationToken ct)
        {
            bool exists = await _categoryRepository.IsCategoryNameExistAsync(newName, ct);

            if (exists)
                throw new IsAlreadyExistException($"Category with name '{newName}' already exists.");
        }
    }
}