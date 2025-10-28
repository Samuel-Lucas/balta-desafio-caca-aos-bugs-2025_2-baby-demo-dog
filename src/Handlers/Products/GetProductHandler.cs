using BugStore.Models;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using src.Repository.Contracts;

namespace src.Handlers.Products;

public class GetProductHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> HandleAsync()
    {
        var products = await _productRepository.GetProductsAsync();
        if (products == null)
        {
            return null!;
        }

        return products;
    }

    public async Task<GetByIdResponse> GetProductById(GetById request)
    {
        var product = await _productRepository.GetProductByIdAsync(request.Id);

        if (product == null)
        {
            return null!;
        }

        var result = new GetByIdResponse
        {
            Title = product.Title,
            Description = product.Description,
            Slug = product.Slug,
            Price = product.Price
        };

        return result;
    }
}