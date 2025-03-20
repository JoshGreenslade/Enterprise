using Chap3.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chap3.Repositories;

public class SQLOrderRepository
{
    private readonly AppDbContext _db;

    public SQLOrderRepository(AppDbContext db)
    {
        _db = db;
    }
        
    public async Task<Order?> GetById(int id)
    {
        return await _db.Orders
            .Include(p => p.OrderItems)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}