
using MakFood.Kitchen.Application.Command.AddProduct;
using MakFood.Kitchen.Application.Command.RemoveProduct;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.UnitOfWorks;
using MakFood.Kitchen.Infrastructure.Persistence.Repository;
using MakFood.Kitchen.Infrastructure.Persistence.Repository.Repositores;
using Microsoft.Extensions.DependencyInjection;

namespace MakFood.Kitchen.Infrastructure.DI
{
    public static class DI
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection services)
        {
            //repo
           
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();


            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AddProductCommandHandller).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveProductCommandHandller).Assembly);
            });

            return services;
        }
    }
}
