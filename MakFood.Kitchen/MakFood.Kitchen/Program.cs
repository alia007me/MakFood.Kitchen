using FluentValidation;
using MakFood.Kitchen.Application.Query.Behavior;
using MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrderByDateRange;
using MakFood.Kitchen.Application.Query.GetTotalSalesByDateRange;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Persistence.Repository;
using MakFood.Kitchen.Infrastructure.Substructure.Settings;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MakFood.Kitchen.Infrastructure.DI;
using System.Reflection;
using MakFood.Kitchen.Application.Command.UpdateCart;
using MakFood.Kitchen.Application.Query.GetCart;
using MakFood.Kitchen.Application.Command.CancelOrder;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(new[]
{
    typeof(GetAllMiseOnPlaceOrdersByDateRangeValidation).Assembly,
    typeof(CancelOrderValidation).Assembly,
    typeof(GetTotalSalesByDateRangeValidation).Assembly
});


builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


var app = builder.Build();
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.EnableTryItOutByDefault();
    });
}
// Configure the HTTP request pipeline.

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();