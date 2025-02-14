using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    public Guid ProductId { get; init; }

    public Guid SaleId { get; init; }

    public decimal Quantity { get; init; }

    public decimal Price { get; init; }

    public decimal Total { get; init; }

    public decimal Discount { get; init; }

    public bool Canceled { get; init; } = false;

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }
}
