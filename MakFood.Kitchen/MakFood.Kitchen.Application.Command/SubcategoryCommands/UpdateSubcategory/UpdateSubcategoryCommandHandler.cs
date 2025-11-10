using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MediatR;


namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.UpdateSubcategory
{
    public partial class UpdateSubcategoryCommandValidator
    {
        public class UpdateSubcategoryCommandHandler
        : IRequestHandler<UpdateSubcategoryCommand, UpdateSubcategoryCommandResponse>
        {
            private readonly ISubcategoryRepository _subcategoryRepository;
            private readonly IUnitOfWork _unitOfWork;

            public UpdateSubcategoryCommandHandler(
                ISubcategoryRepository subcategoryRepository,
                IUnitOfWork unitOfWork)
            {
                _subcategoryRepository = subcategoryRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<UpdateSubcategoryCommandResponse> Handle(UpdateSubcategoryCommand request, CancellationToken ct)
            {
                var subcategory = await _subcategoryRepository.GetByIdAsync(request.Id, ct);
                if (subcategory == null)
                    throw new Exception($"Subcategory with Id '{request.Id}' not found.");

                bool exists = await _subcategoryRepository.ExistNameAsync(request.NewName, ct);
                if (exists)
                    throw new Exception($"Subcategory with name '{request.NewName}' already exists.");

                subcategory.updateSubcategoryName(request.NewName);
                _subcategoryRepository.Update(subcategory);

                await _unitOfWork.commit(ct);

                return new UpdateSubcategoryCommandResponse
                {
                    Id = subcategory.Id
                };
            }
        }

    }
}
