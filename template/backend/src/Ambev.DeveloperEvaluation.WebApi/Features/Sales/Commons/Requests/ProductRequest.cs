namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Requests;

public record ProductRequest
{
    public Guid ProductId { get; init; }
    public decimal Quantity { get; init; }
    public decimal Price { get; init; }
    public decimal Total { get; init; }
}
