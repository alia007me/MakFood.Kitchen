using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
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
                var subcategory = await _categoryRepository.GetSubcategoryByIdAsync(request.Id, ct);

                if (subcategory == null)
                    throw new SubcategoryNotFoundException($"Subcategory with Id '{request.Id}' not found.");
                
                // بررسی نام تکراری در همان Category
                bool nameExists = await _categoryRepository.IsSubcategoryNameExistAsync(subcategory.Id, request.NewName, ct);
                
                if (nameExists)
                    throw new IsAlreadyExistException($"Subcategory with name '{request.NewName}' already exists in the same category.");

                subcategory.updateSubcategoryName(request.NewName);
               
                await _unitOfWork.Commit(ct);

                return new UpdateSubcategoryCommandResponse
                {
                    Id = subcategory.Id
                };
            }
        }

    }
}
