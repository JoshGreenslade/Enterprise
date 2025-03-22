using Chap3.Domain;

namespace Chap3.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(int id);
    Task<Order?> CreateAsync(Order order);
    Task<Order?> UpdateAsync(Order order);
}