namespace Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;

public record SaleCommand
{
    public Guid CustomerId { get; init; }
    public string CustomerName { get; init; } = string.Empty;
    public Guid BranchId { get; init; }
    public string BranchName { get; init; } = string.Empty;
    public decimal TotalValue { get; init; }
    public List<ProductCommand> Products { get; set; } = [];
}
