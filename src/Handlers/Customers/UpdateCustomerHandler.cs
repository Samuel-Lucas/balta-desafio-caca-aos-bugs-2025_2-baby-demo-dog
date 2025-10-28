using BugStore.Requests.Customers;
using src.Repository.Contracts;

namespace src.Handlers.Customers;

public class UpdateCustomerHandler
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(string id, Update request)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(id);

        if (customer is null)
            return;

        customer.Name = request.Name;
        customer.Phone = request.Phone;
        customer.BirthDate = request.BirthDate;

        await _customerRepository.UpdateCustomerAsync(customer);
    }
}