using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken ct)
        {

           await CheckIsCategoryExist(request.Name, ct);


            var category = new Category(request.Name);

            _categoryRepository.Add(category);

            await _unitOfWork.Commit(ct);

            return new CreateCategoryCommandResponse
            {
                Id = category.Id
            };
        }

        private async Task CheckIsCategoryExist(string name, CancellationToken ct)
        {
            bool exists = await _categoryRepository.IsCategoryNameExistAsync(name, ct);
            if (exists)
                throw new IsAlreadyExistException(name);
        }
    }
}
