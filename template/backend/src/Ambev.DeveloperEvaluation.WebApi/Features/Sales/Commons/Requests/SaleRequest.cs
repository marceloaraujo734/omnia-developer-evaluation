namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Requests;

public record SaleRequest
{
    public Guid CustomerId { get; init; }
    public string CustomerName { get; init; } = string.Empty;
    public Guid BranchId { get; init; }
    public string BranchName { get; init; } = string.Empty;
    public decimal TotalValue { get; init; }
    public List<ProductRequest> Products { get; set; } = [];
}
