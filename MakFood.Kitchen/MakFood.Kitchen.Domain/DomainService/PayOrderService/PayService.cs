using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

namespace MakFood.Kitchen.Domain.DomainService.PayOrderService
{
    public class PayService : IPayService
    {
        private IProductRepository _productRepository;
        public PayService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task payOrder(Order order, Guid userId, CancellationToken ct)
        {
            order.Payment.Pay(userId);
            var productsId = order.Consistencies.Select(c => c.ProductId);
            foreach (var productId in productsId) {
                var product = await _productRepository.GetProductByIdAsync(productId, ct);
                DecreaseQuantity(order, product);
            }
        }
        #region behaviar
        private void DecreaseQuantity(Order order, Product product)
        {
            if (product != null) {
                product.DecreaseAvailableQuantity(1);
            }
            else {
                order.Cancelled();
                throw new ProductNotFoundException();
            }
        }
        #endregion
    }
}
