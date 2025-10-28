using BugStore.Models;
using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
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

    public async Task<GetByIdResponse> GetCustomerById(GetById request)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);

        if (customer == null)
        {
            return null!;
        }

        var result = new GetByIdResponse
        {
            Name = customer.Name,
            Email = customer.Email,
            Phone = customer.Phone,
            BirthDate = customer.BirthDate
        };

        return result;
    }
}