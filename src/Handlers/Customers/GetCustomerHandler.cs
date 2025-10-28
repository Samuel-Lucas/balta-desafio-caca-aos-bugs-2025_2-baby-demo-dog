using BugStore.Models;
using src.Repository.Contracts;

namespace src.Handlers.Customers;

public class GetCustomerHandler
{
     private readonly ICustomerRepository _customerRepository;

    public GetCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<Customer>> HandleAsync()
    {
        var customers = await _customerRepository.GetCustomersAsync();
        if (customers == null)
        {
            return null!;
        }

        return customers;
    }
}