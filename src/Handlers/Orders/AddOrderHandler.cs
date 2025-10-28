using BugStore.Requests.Orders;
using src.Repository.Contracts;

namespace src.Handlers.Orders;

public class AddOrderHandler
{
    private readonly IOrderRepository _orderRepository;

    public AddOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(Create request)
    {
        await _orderRepository.AddOrderAsync(request.ToEntity());
    }
}