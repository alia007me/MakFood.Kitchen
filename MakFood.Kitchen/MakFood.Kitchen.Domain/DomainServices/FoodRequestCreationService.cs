using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate;
using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;

namespace MakFood.Kitchen.Domain.DomainServices
{
    public class FoodRequestCreationService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFoodRequestRepository _foodRequestRepository;

        public FoodRequestCreationService(IProductRepository productRepository, IFoodRequestRepository foodRequestRepository)
        {
            _productRepository = productRepository;
            _foodRequestRepository = foodRequestRepository;
        }

        public async Task<FoodRequest> CreationRequest(Guid userId,Guid productId,DateOnly targetdate)
        {
            var targetFood = await _productRepository.IsExistByIdAsync(userId);
            if (!targetFood) throw new Exception("Product not found!");

            var FoodRequestIsAlreadyExist = await _foodRequestRepository.IsAlreadyExistAsync(userId,productId,targetdate);
            if(FoodRequestIsAlreadyExist) throw new Exception("Food request is already exist");

            var newFoodRequest = new FoodRequest(userId, productId, targetdate);

            return newFoodRequest;

        }
    }
}
