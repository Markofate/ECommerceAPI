using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ConnectingApps.SmartInject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<IOrderProductService, OrderProductService>();
builder.Services.AddSingleton<IOrderProductRepository, OrderProductRepository>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IFavoriteService, FavoriteService>();
builder.Services.AddSingleton<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddSingleton<IProductPhotoRepository, ProductPhotoRepository>();
builder.Services.AddSingleton<IProductPhotoService, ProductPhotoService>();

// Register UserService and UserRepository
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

// Register CartService with Lazy<IUserService>
builder.Services.AddSingleton<ICartService>(provider =>
    new CartService(
        provider.GetRequiredService<ICartRepository>(),
        new Lazy<IUserService>(() => provider.GetRequiredService<IUserService>())
    ));

builder.Services.AddSingleton<ICartRepository, CartRepository>();
builder.Services.AddSingleton<ICartProductService, CartProductService>();
builder.Services.AddSingleton<ICartProductRepository, CartProductRepository>();





var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();

    if (!dbContext.Database.CanConnect())
    {
        throw new NotImplementedException("cant connect db");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();