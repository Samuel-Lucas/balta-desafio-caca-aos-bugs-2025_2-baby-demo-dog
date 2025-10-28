using System.Net.Http.Headers;
using System.Text;
using BugStore.Data;
using BugStore.Handlers.Customers;
using BugStore.Requests.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Handlers.Customers;
using src.Repository;
using src.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<GetCustomerHandler>();
builder.Services.AddScoped<AddCustomerHandler>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/v1/customer", async (GetCustomerHandler getCustomerHandler) =>
{
    var response = await getCustomerHandler.HandleAsync();
    if (response == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(response);
});

// app.MapGet("/v1/customers/{id}", () => "Hello World!");

app.MapPost("/v1/customer", async ([FromBody] Create request, AddCustomerHandler addCustomerHandler) =>
{
    if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Email))
    {
        return Results.BadRequest("Nome e Email são obrigatórios.");
    }

    await addCustomerHandler.Handle(request);
    return Results.Created($"Usuario {request.Name} criado com sucesso", request.Name);
});

// app.MapPut("/v1/customers/{id}", () => "Hello World!");
// app.MapDelete("/v1/customers/{id}", () => "Hello World!");

// app.MapGet("/v1/products", () => "Hello World!");
// app.MapGet("/v1/products/{id}", () => "Hello World!");
// app.MapPost("/v1/products", () => "Hello World!");
// app.MapPut("/v1/products/{id}", () => "Hello World!");
// app.MapDelete("/v1/products/{id}", () => "Hello World!");

// app.MapGet("/v1/orders/{id}", () => "Hello World!");
// app.MapPost("/v1/orders", () => "Hello World!");

app.Run();
