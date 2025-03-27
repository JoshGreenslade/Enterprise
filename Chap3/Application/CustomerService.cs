using Chap3.Domain;
using Chap3.Repositories;

namespace Chap3.Application;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Customer> AddNewCustomerAsync(string name)
    {
        var customer = new Customer { Name = name };
        await _customerRepository.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();
        return customer;
    }
}