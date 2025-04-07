
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders")]
public class OrderController : Controller
{
    private readonly OrderService _orderService;
    private readonly ProductService _productService;
    public OrderController(OrderService orderService, ProductService productService)
    {
        _orderService = orderService;
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewOrder([FromBody] NewOrderDto orderDto)
    {
        var order = await _orderService.CreateNewOrder(orderDto.customerId);
        await _productService.AddNewProduct(orderDto.productName);
        var product = await _productService.GetByName(orderDto.productName);
        await _orderService.AddProductToOrder(order.Id, product.Id, 10);
        return Ok(order);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] int customerId)
    {
        var orders = await _orderService.GetOrdersForCustomerAsync(customerId);
        return Ok(orders);
    }


}

public class NewOrderDto
{
    public int customerId { get; set; }
    public required string productName { get; set; }
}