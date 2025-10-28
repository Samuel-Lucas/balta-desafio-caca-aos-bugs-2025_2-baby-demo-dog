using src.Repository.Contracts;

namespace src.Handlers.Customers;

public class DeleteCustomerHandler
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(string id)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(id);

        if (customer is null)
            return;

        await _customerRepository.DeleteCustomerAsync(customer);
    }
}