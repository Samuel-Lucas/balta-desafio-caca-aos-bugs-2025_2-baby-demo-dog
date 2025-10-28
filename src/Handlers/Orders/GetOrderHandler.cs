using BugStore.Requests.Orders;
using BugStore.Responses.Orders;
using src.Repository.Contracts;

namespace src.Handlers.Orders;

public class GetOrderHandler
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<GetByIdResponse> GetOrderById(GetById request)
    {
        var order = await _orderRepository.GetOrderByIdAsync(request.Id);

        if (order == null)
        {
            return null!;
        }

        var result = new GetByIdResponse
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt
        };

        return result;
    }
}