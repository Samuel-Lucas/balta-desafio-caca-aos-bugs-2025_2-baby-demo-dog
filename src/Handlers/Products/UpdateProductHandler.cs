using BugStore.Requests.Products;
using src.Repository.Contracts;

namespace src.Handlers.Products;

public class UpdateProductHandler
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(string id, Update request)
    {
        var product = await _productRepository.GetProductByIdAsync(id);

        if (product is null)
            return;

        product.Title = request.Title;
        product.Description = request.Description;
        product.Slug = request.Slug;
        product.Price = request.Price;

        await _productRepository.UpdateProductAsync(product);
    }
}