namespace Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;

public record ProductCommand
{
    public Guid ProductId { get; init; }
    public decimal Quantity { get; init; }
    public decimal Price { get; init; }
    public decimal Total { get; init; }
}
