using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using System.Collections.Generic;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository
{
    public class OrderRepository : IOrderRepository

    {
        private readonly ApplicationDbContext _applicationDbContext;
        public OrderRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public void AddOrder(Guid customerId, Discount discountCode, Payment payment, List<Constituent> constituents)
        {
            var order = new Order(customerId, discountCode, payment, constituents);
            _applicationDbContext.Orders.Add(order);
        }
    }
}
