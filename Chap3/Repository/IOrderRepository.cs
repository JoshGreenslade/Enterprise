using Chap3.Domain;

namespace Chap3.Repositories;

public interface IOrderRepository
{
    public Task<Order?> GetByIdAsync(int orderId);
    public Task<Order> AddAsync(Order order);
    public Task<Order?> UpdateAsync(Order order);
}