using Chap3.Domain;
using Chap3.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chap3.Repositories;

public class SQLOrderRepository : IOrderRepository
{
    private readonly AppDbContext _db;

    public SQLOrderRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _db.Orders
            .Include(p => p.OrderItems)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Order?> CreateAsync(Order order)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> UpdateAsync(Order order)
    {
        _db.Orders.Entry(order).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return order;
    }
}