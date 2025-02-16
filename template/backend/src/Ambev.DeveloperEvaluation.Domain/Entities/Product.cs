using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    public Product() { }

    private Product(Guid productId, decimal quantity, decimal price, decimal total)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
        Total = total;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid ProductId { get; init; }

    public Guid SaleId { get; init; }

    public decimal Quantity { get; private set; }

    public decimal Price { get; private set; }

    public decimal Total { get; private set; }

    public decimal Discount { get; private set; }

    public bool Canceled { get; private set; } = false;

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }

    public void SetTotal(decimal total) => Total = total;

    public static Product Builder(Guid productId, decimal quantity, decimal price, decimal total)
        => new(productId, quantity, price, total);

    internal void ApplyDiscount(decimal discount)
    {
        Discount = discount;
        Total = Total - (Total * Discount);
    }

    internal void ChangeValues(Product product)
    {
        Quantity = product.Quantity;
        Price = product.Price;
        Total = product.Total;
        Discount = 0.00m;
    }

    public void ChangeToCancelled() => Canceled = true;
}
