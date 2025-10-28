using BugStore.Data;
using BugStore.Models;
using Microsoft.EntityFrameworkCore;
using src.Repository.Contracts;

namespace src.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> GetOrderByIdAsync(string id)
    {
        return await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task AddOrderAsync(Order order)
    {
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
    }
}