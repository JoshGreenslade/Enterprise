using Chap3.Domain;

namespace Chap3.Repositories;

public interface ICustomerRepository
{
    Task<Customer> AddAsync(Customer customer);

    Task<List<Customer>> GetAllCustomersAsync();
}