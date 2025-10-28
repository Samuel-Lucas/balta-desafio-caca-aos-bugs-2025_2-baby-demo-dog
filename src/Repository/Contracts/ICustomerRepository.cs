using BugStore.Models;
using BugStore.Requests.Customers;

namespace src.Repository.Contracts;

public interface ICustomerRepository
{
    Task<List<Customer>> GetCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(string id);
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Customer customer);
}