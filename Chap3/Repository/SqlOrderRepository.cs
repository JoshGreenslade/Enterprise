using Chap3.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chap3.Repositories;

public class SqlOrderRepository : IOrderRepository
{

    private readonly AppDbContext _db;

    public SqlOrderRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Order> AddAsync(Order order)
    {
        await _db.Orders.AddAsync(order);
        return order;
    }

    public async Task<Order?> GetByIdAsync(int orderId)
    {
        return await _db.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }

    public async Task<Order?> UpdateAsync(Order order)
    {
        var existingOrder = await _db.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
        if (existingOrder == null) return null;

        existingOrder.CustomerId = order.CustomerId;
        // existingOrder._orderItems = order.OrderItems;

        return existingOrder;

    }

    public async Task<List<Order>> GetOrdersForCustomer(int customerId)
    {
        return await _db.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
    }
}