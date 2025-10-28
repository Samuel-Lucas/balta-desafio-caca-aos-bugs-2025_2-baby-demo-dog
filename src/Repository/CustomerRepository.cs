using BugStore.Data;
using BugStore.Models;
using Microsoft.EntityFrameworkCore;
using src.Repository.Contracts;

namespace src.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<CustomerRepository> _logger;

    public CustomerRepository(AppDbContext dbContext, ILogger<CustomerRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<List<Customer>> GetCustomersAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(string id)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        try
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao criar usuário: {ex.Message} \n {ex.InnerException}");
        }
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        try
        {
            _dbContext.Customers.Entry(customer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao alterar usuário: {ex.Message} \n {ex.InnerException}");
        }
    }
    
    public async Task DeleteCustomerAsync(Customer customer)
    {
        try
        {
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
        } catch (Exception ex)
        {
            _logger.LogError($"Erro ao deletar usuário: {ex.Message} \n {ex.InnerException}");
        }
    }
}