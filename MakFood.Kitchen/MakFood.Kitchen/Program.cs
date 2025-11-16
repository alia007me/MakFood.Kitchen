using FluentValidation;
using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Settings;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MakFood.Kitchen.Infrastructure.DI;
using MakFood.Kitchen.Application.Query.GetCart;
using MakFood.Kitchen.Application.Command.CancelOrder;
using MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository;
using MakFood.Kitchen.Infrastructure.Substructure.Behavior;
using MakFood.Kitchen.Application.Command.UpdateCart.AddItemToCart;
using MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrdersByDateRange;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract;



var builder = WebApplication.CreateBuilder(args);


var connectionStringConfiguration = builder.Configuration.GetSection(nameof(ConnectionStrings));

builder.Services.Configure<ConnectionStrings>(connectionStringConfiguration);
builder.Services.ConfigureDI();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = connectionStringConfiguration.Get<ConnectionStrings>();
    var connectionBuilder = new SqlConnectionStringBuilder
    {
        DataSource = connectionString.Server,
        InitialCatalog = connectionString.InitialCatalog,
        TrustServerCertificate = true,
        IntegratedSecurity = true
    };
    options.UseSqlServer(connectionBuilder.ConnectionString);
}
);



builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCartQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddItemToCartCommandHandler).Assembly));

builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllMiseOnPlaceOrdersByDateRangeHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CancelOrderCommandHandler).Assembly);
});

builder.Services.AddValidatorsFromAssemblies(new[]
{
    typeof(GetAllMiseOnPlaceOrdersByDateRangeValidation).Assembly,
    typeof(CancelOrderValidation).Assembly
});
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFoodRequestRepository, FoodRequestRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();


var app = builder.Build();
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.EnableTryItOutByDefault();
    });
}

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();