using BugStore.Requests.Customers;
using src.Repository.Contracts;

namespace BugStore.Handlers.Customers;

public class AddCustomerHandler
{
    private readonly ICustomerRepository _customerRepository;

    public AddCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(Create request)
    {
        await _customerRepository.AddCustomerAsync(request.ToEntity());
    }
}