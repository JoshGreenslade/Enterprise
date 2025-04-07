using Chap3.Domain;
using Chap3.Repositories;
using Microsoft.Extensions.Caching.Memory;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMemoryCache _cache;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _cache = cache;
    }

    public async Task<Order> CreateNewOrder(int customerId)
    {
        var order = new Order
        {
            CustomerId = customerId
        };
        await _orderRepository.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();
        return order;
    }

    public async Task AddProductToOrder(int orderId, int productId, int quantity)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        var product = await _productRepository.GetByIdAsync(productId);
        if (order == null || product == null) return;

        order.AddProduct(product, quantity);
        await _orderRepository.UpdateAsync(order);

        await _unitOfWork.SaveChangesAsync();
        _cache.Remove(CacheKeys.OrdersByCustomer(order.CustomerId));
        return;
    }

    public async Task<List<Order>> GetOrdersForCustomerAsync(int customerId)
    {
        if (_cache.TryGetValue(CacheKeys.OrdersByCustomer(customerId), out List<Order> orders))
        {
            return orders;
        }

        orders = await _orderRepository.GetOrdersForCustomer(customerId);
        _cache.SetWithTimeout(CacheKeys.OrdersByCustomer(customerId), orders, TimeSpan.FromMinutes(5));
        return orders;
    }
}