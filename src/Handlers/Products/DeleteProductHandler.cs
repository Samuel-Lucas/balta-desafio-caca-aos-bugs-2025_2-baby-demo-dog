using src.Repository.Contracts;

namespace src.Handlers.Products;

public class DeleteProductHandler
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(string id)
    {
        var customer = await _productRepository.GetProductByIdAsync(id);

        if (customer is null)
            return;

        await _productRepository.DeleteProductAsync(customer);
    }
}