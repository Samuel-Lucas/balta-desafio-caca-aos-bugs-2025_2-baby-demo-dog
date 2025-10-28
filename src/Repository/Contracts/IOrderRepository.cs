using BugStore.Models;

namespace src.Repository.Contracts;

public interface IOrderRepository
{
    Task<Order> GetOrderByIdAsync(string id);
    Task AddOrderAsync(Order order);
}