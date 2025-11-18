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
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRepository productRepository;

        public RemoveProductCommandHandller(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }

        public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = productRepository.GetByIdAsync(request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new ArgumentException("product not found");
            }
            var e = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
             productRepository.RemoveProduct(e);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
