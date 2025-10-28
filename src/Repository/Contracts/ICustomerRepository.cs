using BugStore.Models;

namespace src.Repository.Contracts;

public interface ICustomerRepository
{
    Task<List<Customer>> GetCustomersAsync();
    Task AddCustomerAsync(Customer customer);
}