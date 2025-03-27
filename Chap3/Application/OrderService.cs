using Chap3.Domain;
using Chap3.Repositories;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
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
        return;
    }
}