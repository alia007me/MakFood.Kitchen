using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.RemoveProduct
{
    public class RemoveProductCommandHandller : IRequestHandler<RemoveProductCommand,bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public RemoveProductCommandHandller(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            this._unitOfWork = unitOfWork;
            this._productRepository = productRepository;
        }

        public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            CheckProductsToExistAccordingToId(request.ProductId, cancellationToken);
            var products = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
             _productRepository.RemoveProduct(products);
            await _unitOfWork.Commit(cancellationToken);
            return true;
        }
        /// <summary>
        /// چک میکنه پروداکت وجود داره یا نه بر حسب ایدی پروداکت
        /// </summary>
        /// <param name="productId">ایدی پروداکت</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="Exception">متن اکسپشن</exception>
        private void CheckProductsToExistAccordingToId(Guid productId, CancellationToken cancellationToken)
        {
            var productIsNull = _productRepository.GetByIdAsync(productId, cancellationToken);
            if (productIsNull == null)
            {
                throw new Exception("product not found");
            }
        }
    }
}
