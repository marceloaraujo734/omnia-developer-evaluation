namespace Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;

public record SaleResult
{
    public Guid Id { get; init; }
    public string Number { get; init; } = string.Empty;
    public DateTime OpenDate { get; init; }
    public Guid CustomerId { get; init; }
    public string CustomerName { get; init; } = string.Empty;
    public Guid BranchId { get; init; }
    public string BranchName { get; init; } = string.Empty;
    public decimal TotalValue { get; init; }
    public bool Canceled { get; init; }
    public List<ProductResult> Products { get; set; } = [];
}
