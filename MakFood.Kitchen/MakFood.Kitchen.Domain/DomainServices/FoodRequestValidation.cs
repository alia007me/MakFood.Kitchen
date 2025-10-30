using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate;
using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;

namespace MakFood.Kitchen.Domain.DomainServices
{
    public class FoodRequestValidation : IFoodRequestValidation
    {
        private readonly IProductRepository _productRepository;
        private readonly IFoodRequestRepository _foodRequestRepository;
        private readonly IFoodRequestValidation _foodRequestCreationService;

        public FoodRequestValidation(IProductRepository productRepository, IFoodRequestRepository foodRequestRepository, IFoodRequestValidation foodRequestCreationService)
        {
            _productRepository = productRepository;
            _foodRequestRepository = foodRequestRepository;
            _foodRequestCreationService = foodRequestCreationService;
        }

        public async Task Validation(Guid userId, Guid productId, DateOnly targetdate)
        {
            var targetFood = await _productRepository.IsExistByIdAsync(userId);
            if (!targetFood) throw new Exception("Product not found!");

            var FoodRequestIsAlreadyExist = await _foodRequestRepository.IsAlreadyExistAsync(userId,productId,targetdate);
            if (FoodRequestIsAlreadyExist) throw new Exception("Food request is already exist");

        }
    }
}
