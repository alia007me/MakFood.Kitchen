using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;


namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.UpdateSubcategory
{
    public partial class UpdateSubcategoryCommandValidator
    {
        public class UpdateSubcategoryCommandHandler : IRequestHandler<UpdateSubcategoryCommand, UpdateSubcategoryCommandResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IUnitOfWork _unitOfWork;

            public UpdateSubcategoryCommandHandler(IUnitOfWork unitOfWork ,ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<UpdateSubcategoryCommandResponse> Handle(UpdateSubcategoryCommand request, CancellationToken ct)
            {
                var subcategory = await _categoryRepository.GetSubcategoryByIdAsync(request.SubCategoryId, ct);

                EnsureSubcategoryExists(subcategory,request.SubCategoryId);

                await ValidateUniqueName(subcategory!,subcategory!.Name,ct);

                subcategory.updateSubcategoryName(request.NewName);
               
                await _unitOfWork.Commit(ct);

                return new UpdateSubcategoryCommandResponse
                {
                    Id = subcategory.Id
                };
            }

            private void EnsureSubcategoryExists(Subcategory? subcategory, Guid subcategoryId)
            {
                if (subcategory is null)
                    throw new SubcategoryNotFoundException($"Subcategory with Id '{subcategoryId}' not found.");
            }

            private async Task ValidateUniqueName(Subcategory subcategory, string newName, CancellationToken ct)
            {
                bool nameExists = await _categoryRepository.IsSubcategoryNameExistAsync(subcategory.Id, newName, ct);

                if (nameExists)
                    throw new IsAlreadyExistException($"Subcategory with name '{newName}' already exists in the same category.");
            }
        }

    }
}
