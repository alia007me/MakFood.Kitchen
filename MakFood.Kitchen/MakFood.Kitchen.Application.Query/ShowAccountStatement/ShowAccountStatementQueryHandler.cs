using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MediatR;

namespace MakFood.Kitchen.Application.Query.ShowAccountStatement
{
    public class ShowAccountStatementQueryHandler : IRequestHandler<ShowAccountStatementQuery , ShowAccountStatementQueryResponce>
    {
        private readonly IOrderRepository _orderRepository;
        public ShowAccountStatementQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }

        public async Task<ShowAccountStatementQueryResponce> Handle(ShowAccountStatementQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrderByCustomerIdAsync(request.CustomerId, request.StartDateTime, request.EndDateTime);
            var orderItems = orders.Select(w=> new ShowAccountStatementQueryResponce.ShowAccountStatementItem
            {
                DiscountCode = w.DiscountCode,
                DiscountPrice = w.DiscountPrice,
                Payable = w.Payable,
                Payment = w.Payment,
                Price = w.Price
            }).ToList();
            return new ShowAccountStatementQueryResponce(orderItems);
        }
    }
}
