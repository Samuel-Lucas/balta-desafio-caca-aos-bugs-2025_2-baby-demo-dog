using BugStore.Requests.Orders;
using Microsoft.AspNetCore.Mvc;
using src.Handlers.Orders;

namespace src.Routes
{
    public static class OrderRoutes
    {
        public static void MapOrderRoutes(this IEndpointRouteBuilder app)
        {
            app.MapGet("/v1/order/{id}", async (string id, GetOrderHandler getProductHandler) =>
        {
            GetById request = new() { Id = id };
            var response = await getProductHandler.GetOrderById(request);
            return response is null ? Results.NotFound() : Results.Ok(response);
        });


            app.MapPost("/v1/order", async ([FromBody] Create request, AddOrderHandler addProductHandler) =>
            {
                if (string.IsNullOrEmpty(request.Id) || string.IsNullOrEmpty(request.CustomerId))
                    return Results.BadRequest("Id da orderm e do cliente são obrigatórios.");

                await addProductHandler.Handle(request);
                return Results.Created("/v1/customer", $"Ordem {request.Id} criado com sucesso");
            });
        }
    }
}