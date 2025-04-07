
using Chap3.Domain;
using Chap3.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chap3.Application;

public class GetCustomerByIdHandler : IQueryHandler<GetCustomerByIdCommand, Customer>
{
    private readonly AppDbContext _db;

    public GetCustomerByIdHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Customer> Handle(GetCustomerByIdCommand command)
    {
        return await _db.Customers.FirstOrDefaultAsync(x => x.Id == command.Id);
    }
}
