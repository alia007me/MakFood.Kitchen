using MediatR;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;

namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.RemoveSubcategory
{
    public class RemoveSubcategoryCommandHandler : IRequestHandler<RemoveSubcategoryCommand, RemoveSubcategoryCommandResponse>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveSubcategoryCommandHandler(
            ISubcategoryRepository subcategoryRepository,
            IUnitOfWork unitOfWork)
        {
            _subcategoryRepository = subcategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveSubcategoryCommandResponse> Handle(RemoveSubcategoryCommand request, CancellationToken ct)
        {
            var subcategory = await _subcategoryRepository.GetByIdAsync(request.Id ,ct  );
            if (subcategory == null)
                throw new Exception($"Subcategory with Id '{request.Id}' not found.");

            bool hasProducts = false;
            subcategory.CheckCanBeRemoved(hasProducts);

            _subcategoryRepository.Remove(subcategory);
            await _unitOfWork.commit(ct);

            return new RemoveSubcategoryCommandResponse
            {
                Id = subcategory.Id
            };
        }
    }
    }
