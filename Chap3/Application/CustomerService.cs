using Chap3.Domain;
using Chap3.Repositories;

namespace Chap3.Application;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> AddNewCustomerAsync(string name)
    {
        var customer = new Customer { Id = (int)new Random().NextInt64(), Name = name };
        await _customerRepository.AddAsync(customer);
        return customer;
    }
}