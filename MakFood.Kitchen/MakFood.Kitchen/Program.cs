using FluentValidation;
using MakFood.Kitchen.Application.Command.CancelOrder;
using MakFood.Kitchen.Application.Command.CategoriesCommand.CreateCategory;
using MakFood.Kitchen.Application.Query.GetFilteredProductsQuery;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Persistence.Repository.Repository;
using MakFood.Kitchen.Infrastructure.Substructure.Behavior;
using MakFood.Kitchen.Infrastructure.Substructure.Settings;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionStringConfiguration = builder.Configuration.GetSection(nameof(ConnectionStrings));

builder.Services.Configure<ConnectionStrings>(connectionStringConfiguration);

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

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository,CategoriesRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetFilteredProductsQueryHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CancelOrderCommandHandler).Assembly);
});

builder.Services.AddValidatorsFromAssemblies(new[]
{
    typeof(GetFilteredProductsQueryHandler).Assembly,
    typeof(CancelOrderValidation).Assembly
});


builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));





var app = builder.Build();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.

app.UseAuthorization();


app.MapControllers();

app.Run();