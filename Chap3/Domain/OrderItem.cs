namespace Chap3.Domain;

public class OrderItem
{
    public int Id { get; set; }

    public Order Order { get; set; }

    public Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public OrderItem(Order order, Product product, int quantity, decimal unitPrice)
    {
        ArgumentNullException.ThrowIfNull(order);
        ArgumentNullException.ThrowIfNull(product);
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (unitPrice <= 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));

        Order = order;
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}