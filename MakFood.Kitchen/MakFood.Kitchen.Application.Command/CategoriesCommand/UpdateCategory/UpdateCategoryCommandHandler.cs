using MediatR;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

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

            if (category == null)
                throw new CategoryNotFoundException($"Category with Id '{request.Id}' not found.");

            bool exists = await _categoryRepository.IsCategoryNameExistAsync(request.NewName, ct);

            if (exists)
                throw new IsAlreadyExistException($"Category with name '{request.NewName}' already exists.");

            category.UpdateCategoryName(request.NewName);
                       
            await _unitOfWork.Commit(ct);

            return new UpdateCategoryCommandResponse
            {
                Id = category.Id
            };
        }
    }
}
