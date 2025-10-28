using BugStore.Requests.Products;
using src.Repository.Contracts;

namespace src.Handlers.Products;

public class AddProductHandler
{
    private readonly IProductRepository _productRepository;

    public AddProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(Create request)
    {
        await _productRepository.AddProductAsync(request.ToEntity());
    }
}