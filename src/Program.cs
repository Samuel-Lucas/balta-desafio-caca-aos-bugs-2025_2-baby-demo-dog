using BugStore.Data;
using BugStore.Handlers.Customers;
using Microsoft.EntityFrameworkCore;
using src.Handlers.Customers;
using src.Handlers.Products;
using src.Repository;
using src.Repository.Contracts;
using src.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<GetCustomerHandler>();
builder.Services.AddScoped<AddCustomerHandler>();
builder.Services.AddScoped<UpdateCustomerHandler>();
builder.Services.AddScoped<DeleteCustomerHandler>();

builder.Services.AddScoped<GetProductHandler>();
builder.Services.AddScoped<AddProductHandler>();
builder.Services.AddScoped<UpdateProductHandler>();
builder.Services.AddScoped<DeleteProductHandler>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapCustomerRoutes();
app.MapProductRoutes();

app.MapGet("/v1/orders/{id}", () => "Hello World!");
app.MapPost("/v1/orders", () => "Hello World!");

app.Run();
