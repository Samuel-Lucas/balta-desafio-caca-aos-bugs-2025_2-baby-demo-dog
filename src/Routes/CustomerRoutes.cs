using BugStore.Handlers.Customers;
using BugStore.Requests.Customers;
using Microsoft.AspNetCore.Mvc;
using src.Handlers.Customers;

namespace src.Routes;

public static class CustomerRoutes
{
    public static void MapCustomerRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/customer", async (GetCustomerHandler getCustomerHandler) =>
        {
            var response = await getCustomerHandler.HandleAsync();
            return response is null ? Results.NotFound() : Results.Ok(response);
        });

        app.MapGet("/v1/customer/{id}", async (string id, GetCustomerHandler getCustomerHandler) =>
        {
            GetById request = new() { Id = id };
            var response = await getCustomerHandler.GetCustomerById(request);
            return response is null ? Results.NotFound() : Results.Ok(response);
        });

        app.MapPost("/v1/customer", async ([FromBody] Create request, AddCustomerHandler addCustomerHandler) =>
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Email))
                return Results.BadRequest("Nome e Email são obrigatórios.");

            await addCustomerHandler.Handle(request);
            return Results.Created("/v1/customer", $"Usuário {request.Name} criado com sucesso");
        });

        app.MapPut("/v1/customer/{id}", async (string id, [FromBody] Update request, UpdateCustomerHandler updateCustomerHandler) =>
        {
            if (request is null)
                return Results.BadRequest("Obrigatório informar dados a atualizar");

            await updateCustomerHandler.Handle(id, request);
            return Results.Ok($"Usuário {request.Name} alterado com sucesso");
        });

        app.MapDelete("/v1/customer/{id}", async (string id, DeleteCustomerHandler deleteCustomerHandler) =>
        {
            if (string.IsNullOrEmpty(id))
                return Results.BadRequest("Obrigatório informar o ID");

            await deleteCustomerHandler.Handle(id);
            return Results.Ok($"Usuário de id {id} deletado com sucesso");
        });
    }
}