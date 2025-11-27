using MakFood.Kitchen.Application.Command.CancelOrder;
using MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrdersByDateRange;
using MakFood.Kitchen.Domain.DomainService.PayOrderService;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace MakFood.Kitchen.Infrastructure.DI
{
    public static class DI
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection services)
        {
            //repo
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IFoodRequestRepository, FoodRequestRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IFoodRequestRepository, FoodRequestRepository>();
            services.AddScoped<IPayService, PayService>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetAllMiseOnPlaceOrdersByDateRangeHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CancelOrderCommandHandler).Assembly);
            });

            //unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            return services;
        }
    }
}
