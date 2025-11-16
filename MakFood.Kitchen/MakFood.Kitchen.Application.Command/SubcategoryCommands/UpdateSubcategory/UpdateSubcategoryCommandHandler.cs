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
                var category = await _categoryRepository.GetBySubcategoryIdAsync(request.Id, ct);

                if (category == null)
                    throw new EntityNotFoundException($"category with Id '{request.Id}' not found.");

                var subcategory = category.Subcategories.First(s => s.Id == request.Id);

                if (category.Subcategories.Any(s => s.Name == request.NewName && s.Id != subcategory.Id))
                    throw new IsAlreadyExistException($"Subcategory with name '{request.NewName}' already exists.");
                
                subcategory.updateSubcategoryName(request.NewName);
               
                await _unitOfWork.commit(ct);

                return new UpdateSubcategoryCommandResponse
                {
                    Id = subcategory.Id
                };
            }
        }

    }
}
