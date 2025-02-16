namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Responses;

public record ProductResponse
{
    public Guid ProductId { get; init; }
    public decimal Quantity { get; init; }
    public decimal Price { get; init; }
    public decimal Total { get; init; }
    public decimal Discount { get; init; }
    public bool Canceled { get; init; }
}
