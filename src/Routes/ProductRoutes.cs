using BugStore.Requests.Products;
using Microsoft.AspNetCore.Mvc;
using src.Handlers.Products;

namespace src.Routes;

public static class ProductRoutes
{
    public static void MapProductRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/product", async (GetProductHandler getProductHandler) =>
        {
            var response = await getProductHandler.HandleAsync();
            return response is null ? Results.NotFound() : Results.Ok(response);
        });

        app.MapGet("/v1/product/{id}", async (string id, GetProductHandler getProductHandler) =>
        {
            GetById request = new() { Id = id };
            var response = await getProductHandler.GetProductById(request);
            return response is null ? Results.NotFound() : Results.Ok(response);
        });

        app.MapPost("/v1/product", async ([FromBody] Create request, AddProductHandler addProductHandler) =>
        {
            if (string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Description))
                return Results.BadRequest("Titulo e Descrição são obrigatórios.");

            await addProductHandler.Handle(request);
            return Results.Created("/v1/customer", $"Produto {request.Title} criado com sucesso");
        });

        app.MapPut("/v1/product/{id}", async (string id, [FromBody] Update request, UpdateProductHandler updateProductHandler) =>
        {
            if (request is null)
                return Results.BadRequest("Obrigatório informar dados a atualizar");

            await updateProductHandler.Handle(id, request);
            return Results.Ok($"Produto {request.Title} alterado com sucesso");
        });

        app.MapDelete("/v1/product/{id}", async (string id, DeleteProductHandler deleteProductHandler) =>
        {
            if (string.IsNullOrEmpty(id))
                return Results.BadRequest("Obrigatório informar o ID");

            await deleteProductHandler.Handle(id);
            return Results.Ok($"Produto de id {id} deletado com sucesso");
        });
    }
}