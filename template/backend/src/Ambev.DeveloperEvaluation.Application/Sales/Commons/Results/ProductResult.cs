namespace Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;

public record ProductResult
{
    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public decimal Quantity { get; init; }
    public decimal Price { get; init; }
    public decimal Total { get; init; }
    public decimal Discount { get; init; }
}
