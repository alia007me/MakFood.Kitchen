using MakFood.Kitchen.Application.Command.AddProduct;
using MakFood.Kitchen.Application.Query.ShowAccountStatement;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using MakFood.Kitchen.Infrastructure.Persistence.Context.UnitOfWorks;
using MakFood.Kitchen.Infrastructure.Persistence.Repository.Repositores;
using MakFood.Kitchen.Infrastructure.Substructure.Settings;
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


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();