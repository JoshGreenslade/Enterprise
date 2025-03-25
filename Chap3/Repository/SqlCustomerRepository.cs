using Chap3.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chap3.Repositories;

public class SqlCustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _db;

    public SqlCustomerRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        await _db.Customers.AddAsync(customer);
        await _db.SaveChangesAsync();
        return customer;
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _db.Customers.ToListAsync();
    }
}